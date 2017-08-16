using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using yanzhilong.filter;
using yanzhilong.Domain;
using yanzhilong.Models;
using yanzhilong.Service;
using yanzhilong.Infrastructure.Mapper;
using yanzhilong.Helper;
using Newtonsoft.Json;

namespace yanzhilong.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleServiceMB _RoleServiceMB;
        private readonly RolePermissionRecordServiceMB _RolePermissionRecordServiceMB;

        public RoleController(RoleServiceMB roleServiceMB, RolePermissionRecordServiceMB rolePermissionRecordServiceMB)
        {
            this._RoleServiceMB = roleServiceMB;
            this._RolePermissionRecordServiceMB = rolePermissionRecordServiceMB;
        }

        [Authentication]
        public ActionResult Index()
        {
            return View();
        }
        
        [JsonCallback]
        public ActionResult List()
        {
            var entrys = _RoleServiceMB.GetEntrys(new Role{ });

            IEnumerable<RoleModel> entrymodels = entrys.Select(x => x.ToModel());

            return Json(entrymodels);
        }

        [JsonCallback]
        public ActionResult Update()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<RoleModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<Role> entrys = models.Select(e => e.ToEntity());
                _RoleServiceMB.UpdateEntrys(entrys.ToList <Role> ());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Create()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<RoleModel>>(Request.Params["models"]);

            if (models != null)
            {
                foreach (RoleModel entry in models)
                {
                    entry.Id = Guid.NewGuid().ToString();
                }
                IEnumerable<Role> entrys = models.Select(e => e.ToEntity());
                _RoleServiceMB.AddEntrys(entrys.ToList<Role>());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Delete()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<RoleModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<Role> entrys = models.Select(e => e.ToEntity());
                _RoleServiceMB.DeleteEntrys(entrys.ToList<Role>());
            }
            return Json(models);
        }

        public ActionResult Details(string Id)
        {
            Role role = _RoleServiceMB.GetEntry(new Role { Id = Id });

            IEnumerable<RolePermissionRecord> RolePermissionRecords =_RolePermissionRecordServiceMB.GetEntrys(new RolePermissionRecord { Role = new Role { Id = role.Id } });
            role.PermissionRecords = RolePermissionRecords.Select(rpr => rpr.PermissionRecord).ToList<PermissionRecord>();
            return View(role);
        }

        public ActionResult Update(string RoleId, List<string> PermissionRecordIds)
        {
            //删除当前角色的所有权限
            List<RolePermissionRecord> deletes = _RolePermissionRecordServiceMB.GetEntrys(new RolePermissionRecord { Role = new Role { Id = RoleId } }).ToList<RolePermissionRecord>();
            _RolePermissionRecordServiceMB.DeleteEntrys(deletes);

            //添加当前角色权限
            Role role = new Role { Id = RoleId };
            List<RolePermissionRecord> rprs = new List<RolePermissionRecord>();
            foreach(string id in PermissionRecordIds)
            {
                RolePermissionRecord rpr = new RolePermissionRecord();
                rpr.Id = Guid.NewGuid().ToString();
                rpr.Role = role;
                rpr.PermissionRecord = new PermissionRecord { Id = id };
                rprs.Add(rpr);
            }
            IEnumerable<RolePermissionRecord> RolePermissionRecords = _RolePermissionRecordServiceMB.GetEntrys(new RolePermissionRecord { Role = new Role { Id = role.Id } });
            role.PermissionRecords = RolePermissionRecords.Select(rpr => rpr.PermissionRecord).ToList<PermissionRecord>();
            return RedirectToAction("Detail", new { Id = RoleId });
        }
    }
}