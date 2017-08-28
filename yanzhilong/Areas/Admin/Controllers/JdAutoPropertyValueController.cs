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
    public class JdAutoPropertyValueController : BaseAdminController
    {
        private readonly JdAutoPropertyValueServiceMB _JdAutoPropertyValueMB;

        public JdAutoPropertyValueController(JdAutoPropertyValueServiceMB jdAutoPropertyValueMB)
        {
            _JdAutoPropertyValueMB = jdAutoPropertyValueMB;
        }

        public ActionResult Index(string JdAutoId)
        {
            if (!Authorize(PermissionRecordProvider.ManageJdAuto))
                return AccessDeniedView();
            ViewBag.JdAutoId = JdAutoId;
            JdAutoPropertyValueModel jpv = new JdAutoPropertyValueModel();
            List<SelectListItem> CheckItems = new List<SelectListItem>();
            CheckItems.Add(new SelectListItem { Value = "0", Text = "否" });
            CheckItems.Add(new SelectListItem { Value = "1", Text = "是" });
            jpv.CheckItems = CheckItems;
            return View(jpv);
        }
        
        [JsonCallback]
        public ActionResult List(string JdAutoId)
        {
            if (!Authorize(PermissionRecordProvider.ManageJdAuto))
                return AuthorizeGrid();

            var entrys = _JdAutoPropertyValueMB.GetEntrys(new JdAutoPropertyValue { JdAutoId = JdAutoId });
            IEnumerable<JdAutoPropertyValueModel> entrymodels = entrys.Select(x => x.ToModel());
            return Json(entrymodels);
        }

        [JsonCallback]
        public ActionResult Update()
        {
            if (!Authorize(PermissionRecordProvider.ManageJdAuto))
                return AuthorizeGrid();

            var models = JsonConvert.DeserializeObject<IEnumerable<JdAutoPropertyValueModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<JdAutoPropertyValue> entrys = models.Select(e => e.ToEntity());
                _JdAutoPropertyValueMB.UpdateEntrys(entrys.ToList <JdAutoPropertyValue> ());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Create()
        {
            if (!Authorize(PermissionRecordProvider.ManageJdAuto))
                return AuthorizeGrid();

            var models = JsonConvert.DeserializeObject<IEnumerable<JdAutoPropertyValueModel>>(Request.Params["models"]);

            if (models != null)
            {
                foreach (JdAutoPropertyValueModel entry in models)
                {
                    entry.Id = Guid.NewGuid().ToString();
                }
                IEnumerable<JdAutoPropertyValue> entrys = models.Select(e => e.ToEntity());
                _JdAutoPropertyValueMB.AddEntrys(entrys.ToList<JdAutoPropertyValue>());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Delete()
        {
            if (!Authorize(PermissionRecordProvider.ManageJdAuto))
                return AuthorizeGrid();

            var callback = Request.Params["callback"];
            var models = JsonConvert.DeserializeObject<IEnumerable<JdAutoPropertyValueModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<JdAutoPropertyValue> entrys = models.Select(e => e.ToEntity());
                
                //删除分类
                _JdAutoPropertyValueMB.DeleteEntrys(entrys.ToList<JdAutoPropertyValue>());
            }
            return Json(models);
        }
    }
}