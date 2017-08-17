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
        private readonly PermissionRecordServiceMB _PermissionRecordServiceMB;


        public RoleController(RoleServiceMB roleServiceMB, 
            RolePermissionRecordServiceMB rolePermissionRecordServiceMB,
            PermissionRecordServiceMB permissionRecordServiceMB)
        {
            this._RoleServiceMB = roleServiceMB;
            this._RolePermissionRecordServiceMB = rolePermissionRecordServiceMB;
            this._PermissionRecordServiceMB = permissionRecordServiceMB;
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

            IEnumerable<PermissionRecord> PermissionRecords = _PermissionRecordServiceMB.GetEntrys(new PermissionRecord { });
            IEnumerable<RolePermissionRecord> RolePermissionRecords =_RolePermissionRecordServiceMB.GetEntrys(new RolePermissionRecord { Role = new Role { Id = role.Id } });

            List<PermissionRecordModel> PermissionRecordModels = PermissionRecords.Select(pr => pr.ToModel()).ToList();

            foreach(PermissionRecordModel prm in PermissionRecordModels)
            {
                IEnumerable<RolePermissionRecord> rprs = RolePermissionRecords.Where(rp => rp.PermissionRecord.SystemName.Equals(prm.SystemName));
                if(rprs.Count() > 0)
                {
                    prm.Authorize = true;
                }
            }
            ViewBag.PermissionRecords = PermissionRecordModels;
            return View(role.ToModel());
        }

        [HttpPost]
        public ActionResult Update(RoleModel RoleModel, FormCollection form)
        {
            //删除当前角色的所有权限
            List<RolePermissionRecord> deletes = _RolePermissionRecordServiceMB.GetEntrys(new RolePermissionRecord { Role = new Role { Id = RoleModel.Id } }).ToList<RolePermissionRecord>();
            _RolePermissionRecordServiceMB.DeleteEntrys(deletes);

            //添加当前角色权限
            List<PermissionRecord> AllPermissionRecords = _PermissionRecordServiceMB.GetEntrys(new PermissionRecord { }).ToList();
            Role role = new Role { Id = RoleModel.Id };
            List<PermissionRecord> PermissionRecords = new List<PermissionRecord>();
            List<RolePermissionRecord> RolePermissionRecords = new List<RolePermissionRecord>();

            foreach (PermissionRecord PermissionRecord in AllPermissionRecords)
            {
                string formKey = "allow_" + PermissionRecord.Id;
                var permissionRecordSystemNamesToRestrict = form[formKey] != null ? form[formKey].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList() : new List<string>();
                foreach (var pr in AllPermissionRecords)
                {
                    bool allow = permissionRecordSystemNamesToRestrict.Contains(pr.SystemName);
                    if (allow)
                    {
                        if (PermissionRecords.Count(x => x.Id == pr.Id) == 0)
                        {
                            PermissionRecords.Add(pr);
                        }
                    }
                }
            }

            foreach (PermissionRecord pr in PermissionRecords)
            {
                RolePermissionRecord rpr = new RolePermissionRecord();
                rpr.Id = Guid.NewGuid().ToString();
                rpr.Role = role;
                rpr.PermissionRecord = new PermissionRecord { Id = pr.Id };
                RolePermissionRecords.Add(rpr);
            }
            _RolePermissionRecordServiceMB.AddEntrys(RolePermissionRecords);
            return RedirectToAction("Details", new { Id = RoleModel.Id });
        }
    }
}