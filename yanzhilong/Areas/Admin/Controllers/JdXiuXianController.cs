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
    public class JdXiuXianController : BaseAdminController
    {
        private JdXiuXianServiceMB jdXiuXianServiceMB = new JdXiuXianServiceMB();

        public ActionResult Index()
        {
            if (!Authorize(PermissionRecordProvider.ManageJdXiuXian))
                return AccessDeniedView();

            return View();
        }
        
        [JsonCallback]
        public ActionResult List()
        {
            if (!Authorize(PermissionRecordProvider.ManageJdXiuXian))
                return AuthorizeGrid();

            var entrys = jdXiuXianServiceMB.GetEntrys(null);
            IEnumerable<JdXiuXianModel> entrymodels = entrys.Select(x => x.ToModel());
            return Json(entrymodels);
        }

        [JsonCallback]
        public ActionResult Update()
        {
            if (!Authorize(PermissionRecordProvider.ManageJdXiuXian))
                return AuthorizeGrid();

            var models = JsonConvert.DeserializeObject<IEnumerable<JdXiuXianModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<JdXiuXian> entrys = models.Select(e => e.ToEntity());
                jdXiuXianServiceMB.UpdateEntrys(entrys.ToList <JdXiuXian> ());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Create()
        {
            if (!Authorize(PermissionRecordProvider.ManageJdXiuXian))
                return AuthorizeGrid();

            var models = JsonConvert.DeserializeObject<IEnumerable<JdXiuXianModel>>(Request.Params["models"]);

            if (models != null)
            {
                foreach (JdXiuXianModel entry in models)
                {
                    entry.Id = Guid.NewGuid().ToString();
                }
                IEnumerable<JdXiuXian> entrys = models.Select(e => e.ToEntity());
                jdXiuXianServiceMB.AddEntrys(entrys.ToList<JdXiuXian>());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Delete()
        {
            if (!Authorize(PermissionRecordProvider.ManageJdXiuXian))
                return AuthorizeGrid();

            var callback = Request.Params["callback"];
            var models = JsonConvert.DeserializeObject<IEnumerable<JdXiuXianModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<JdXiuXian> entrys = models.Select(e => e.ToEntity());

                //删除分类
                jdXiuXianServiceMB.DeleteEntrys(entrys.ToList<JdXiuXian>());
            }
            return Json(models);
        }
    }
}