using System;
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

        public UserController(UserService userService)
        {
            this._UserService = userService;
        }

        [Authentication]
        public ActionResult Index()
        {
            string UserId = (string)HttpContext.Session["UserID"];
            User user = _UserService.GetEntry(new User { Id = UserId });
            return View(user.ToModel());
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