﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yanzhilong.Domain;
using yanzhilong.filter;
using yanzhilong.Helper;
using yanzhilong.Infrastructure.Mapper;
using yanzhilong.Models;
using yanzhilong.Service;

namespace yanzhilong.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _UserService;
        private readonly UserRoleServiceMB _UserRoleServiceMB;
        private readonly RoleServiceMB _RoleServiceMB;



        public UserController(UserService userService,
            UserRoleServiceMB userRoleServiceMB,
            RoleServiceMB roleServiceMB)
        {
            this._UserService = userService;
            this._UserRoleServiceMB = userRoleServiceMB;
            this._RoleServiceMB = roleServiceMB;
        }

        [Authentication]
        public ActionResult Index()
        {
            return View();
        }

        [JsonCallback]
        public ActionResult List()
        {
            var entrys = _UserService.GetEntrys(new User { });

            IEnumerable<UserModel> entrymodels = entrys.Select(x => x.ToModel());

            return Json(entrymodels);
        }

        [Authentication]
        public ActionResult Details()
        {
            string UserId = (string)HttpContext.Session["UserID"];
            User user = _UserService.GetEntry(new User { Id = UserId });
            return View(user.ToModel());
        }

        [Authentication]
        public ActionResult Role(string Id)
        {
            User user = _UserService.GetEntry(new User { Id = Id });

            IEnumerable<Role> roles = _RoleServiceMB.GetEntrys(new Role { });
            IEnumerable<UserRole> userRoles = _UserRoleServiceMB.GetEntrys(new UserRole { user = new Domain.User { Id = Id } });

            List<RoleModel> RoleModels = roles.Select(x => x.ToModel()).ToList();

            foreach (RoleModel rm in RoleModels)
            {
                IEnumerable<UserRole> urs = userRoles.Where(ur => ur.role.SystemName.Equals(rm.SystemName));
                if (urs.Count() > 0)
                {
                    rm.Authorize = true;
                }
            }

            ViewBag.Roles = RoleModels;
            return View(user.ToModel());
        }

        [HttpPost]
        [Authentication]
        public ActionResult Role(UserModel UserModel, FormCollection form)
        {
            //删除当前用户的所有角色
            List<UserRole> deletes = _UserRoleServiceMB.GetEntrys(new UserRole { user = new User { Id = UserModel.Id } }).ToList<UserRole>();
            _UserRoleServiceMB.DeleteEntrys(deletes);

            //添加当前用户角色
            List<Role> AllRoles = _RoleServiceMB.GetEntrys(new Role { }).ToList();
            User user = new User { Id = UserModel.Id };
            List<Role> Roles = new List<Role>();
            List<UserRole> UserRoles = new List<UserRole>();

            foreach (Role role in AllRoles)
            {
                string formKey = "allow_" + role.Id;
                var permissionRecordSystemNamesToRestrict = form[formKey] != null ? form[formKey].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList() : new List<string>();
                foreach (var r in AllRoles)
                {
                    bool allow = permissionRecordSystemNamesToRestrict.Contains(r.SystemName);
                    if (allow)
                    {
                        if (Roles.Count(x => x.Id == r.Id) == 0)
                        {
                            Roles.Add(r);
                        }
                    }
                }
            }

            foreach (Role r in Roles)
            {
                UserRole ur = new UserRole();
                ur.Id = Guid.NewGuid().ToString();
                ur.user = user;
                ur.role = new Role { Id = r.Id };
                UserRoles.Add(ur);
            }
            _UserRoleServiceMB.AddEntrys(UserRoles);
            return RedirectToAction("Role", new { Id = UserModel.Id });
        }

        [HttpPost]
        [Authentication]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserModel userModel)
        {
            User user = _UserService.GetEntry(new User { Id = userModel.Id });
            user.Email = userModel.Email;
            user.PhoneNumber = userModel.PhoneNumber;
            user.DisplayName = userModel.DisplayName;
            UseUpdateResult useUpdateResult = _UserService.UpdateUserInfo(user);
            if (useUpdateResult.Success)
            {
                return View("ModifyUserInfoSuccess");
            }
            foreach (string error in useUpdateResult.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return View("Index",userModel);
        }

        [Authentication]
        public ActionResult ModifyPassword()
        {
            UserModifyPasswordModel umpm = new UserModifyPasswordModel();
            umpm.Id = (string)HttpContext.Session["UserID"];
            return View(umpm);
        }

        [HttpPost]
        [Authentication]
        [ValidateAntiForgeryToken]
        public ActionResult ModifyPassword(UserModifyPasswordModel umpm)
        {
            if (!ModelState.IsValid)
            {
                return View(umpm);
            }
            UseModifyPasswordResult umpr = _UserService.ModifyPassword(umpm.Id, umpm.PasswordOld, umpm.PasswordNew);
            if (umpr.Success)
            {
                return View("ModifyPasswordSuccess");
            }
            foreach (string error in umpr.Errors)
            {
                ModelState.AddModelError("",error);
            }
            return View(umpm);
        }
    }
}