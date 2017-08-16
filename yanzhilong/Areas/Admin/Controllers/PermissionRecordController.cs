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
using Newtonsoft.Json;

namespace yanzhilong.Areas.Admin.Controllers
{
    public class PermissionRecordController : Controller
    {
        private readonly PermissionRecordServiceMB _PermissionRecordServiceMB;

        public PermissionRecordController(PermissionRecordServiceMB permissionRecordServiceMB)
        {
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
            var entrys = _PermissionRecordServiceMB.GetEntrys(new PermissionRecord { });

            IEnumerable<PermissionRecordModel> entrymodels = entrys.Select(x => x.ToModel());

            return Json(entrymodels);
        }

        [JsonCallback]
        public ActionResult Update()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<PermissionRecordModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<PermissionRecord> entrys = models.Select(e => e.ToEntity());
                _PermissionRecordServiceMB.UpdateEntrys(entrys.ToList <PermissionRecord> ());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Create()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<PermissionRecordModel>>(Request.Params["models"]);

            if (models != null)
            {
                foreach (PermissionRecordModel entry in models)
                {
                    entry.Id = Guid.NewGuid().ToString();
                }
                IEnumerable<PermissionRecord> entrys = models.Select(e => e.ToEntity());
                _PermissionRecordServiceMB.AddEntrys(entrys.ToList<PermissionRecord>());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Delete()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<PermissionRecordModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<PermissionRecord> entrys = models.Select(e => e.ToEntity());
                _PermissionRecordServiceMB.DeleteEntrys(entrys.ToList<PermissionRecord>());
            }
            return Json(models);
        }

    }
}