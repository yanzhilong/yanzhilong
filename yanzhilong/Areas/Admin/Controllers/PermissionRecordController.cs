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
using yanzhilong.Security;

namespace yanzhilong.Areas.Admin.Controllers
{
    public class PermissionRecordController : BaseAdminController
    {
        private readonly PermissionRecordServiceMB _PermissionRecordServiceMB;

        public PermissionRecordController(PermissionRecordServiceMB permissionRecordServiceMB)
        {
            this._PermissionRecordServiceMB = permissionRecordServiceMB;
        }

        public ActionResult Index()
        {
            if (!Authorize(PermissionRecordProvider.ManagePermissionRecord))
                return AccessDeniedView();

            return View();
        }
        
        [JsonCallback]
        public ActionResult List()
        {
            if (!Authorize(PermissionRecordProvider.ManagePermissionRecord))
                return AuthorizeGrid();

            var entrys = _PermissionRecordServiceMB.GetEntrys(new PermissionRecord { });

            IEnumerable<PermissionRecordModel> entrymodels = entrys.Select(x => x.ToModel());

            return Json(entrymodels);
        }

        [JsonCallback]
        public ActionResult Update()
        {
            if (!Authorize(PermissionRecordProvider.ManagePermissionRecord))
                return AuthorizeGrid();

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
            if (!Authorize(PermissionRecordProvider.ManagePermissionRecord))
                return AuthorizeGrid();

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
            if (!Authorize(PermissionRecordProvider.ManagePermissionRecord))
                return AuthorizeGrid();

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