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
using yanzhilong.Security;

namespace yanzhilong.Areas.Admin.Controllers
{
    public class JdItemController : BaseAdminController
    {
        private readonly JdItemServiceMB _JdItemServiceMB;

        public JdItemController(JdItemServiceMB jdItemServiceMB)
        {
            _JdItemServiceMB = jdItemServiceMB;
        }

        public ActionResult Index()
        {
            if (!Authorize(PermissionRecordProvider.ManageJdItem))
                return AccessDeniedView();

            return View();
        }
        
        [JsonCallback]
        public ActionResult List()
        {
            if (!Authorize(PermissionRecordProvider.ManageJdItem))
                return AuthorizeGrid();

            var entrys = _JdItemServiceMB.GetEntrys(new JdItem { });
            IEnumerable<JdItemModel> entrymodels = entrys.Select(x => x.ToModel());
            return Json(entrymodels);
        }

        [JsonCallback]
        public ActionResult Update()
        {
            if (!Authorize(PermissionRecordProvider.ManageJdItem))
                return AuthorizeGrid();

            var models = JsonConvert.DeserializeObject<IEnumerable<JdItemModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<JdItem> entrys = models.Select(e => e.ToEntity());
                _JdItemServiceMB.UpdateEntrys(entrys.ToList <JdItem> ());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Create()
        {
            if (!Authorize(PermissionRecordProvider.ManageJdItem))
                return AuthorizeGrid();

            var models = JsonConvert.DeserializeObject<IEnumerable<JdItemModel>>(Request.Params["models"]);

            if (models != null)
            {
                foreach (JdItemModel entry in models)
                {
                    entry.Id = Guid.NewGuid().ToString();
                    entry.CreateAt = DateTime.Now;
                }
                IEnumerable<JdItem> entrys = models.Select(e => e.ToEntity());
                _JdItemServiceMB.AddEntrys(entrys.ToList<JdItem>());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Delete()
        {
            if (!Authorize(PermissionRecordProvider.ManageJdItem))
                return AuthorizeGrid();

            var callback = Request.Params["callback"];
            var models = JsonConvert.DeserializeObject<IEnumerable<JdItemModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<JdItem> entrys = models.Select(e => e.ToEntity());
                _JdItemServiceMB.DeleteEntrys(entrys.ToList<JdItem>());
            }
            return Json(models);
        }
    }
}