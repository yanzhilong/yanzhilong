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
    public class TbItemController : Controller
    {
        private TbItemService tbItemService = new TbItemService();

        [Authentication]
        public ActionResult Index()
        {
            return View();
        }

        [JsonCallback]
        public ActionResult List()
        {
            var entrys = tbItemService.GetEntrys(new TbItem() { datatype = -1 });
            IEnumerable<TbItemModel> entrymodels = entrys.Select(x => x.ToModel());
            return Json(entrymodels);
        }

        [HttpPost]
        [JsonCallback]
        public ActionResult Update()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<TbItemModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<TbItem> entrys = models.Select(e => e.ToEntity());
                tbItemService.UpdateEntrys(entrys.ToList <TbItem> ());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Create()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<TbItemModel>>(Request.Params["models"]);

            if (models != null)
            {
                foreach (TbItemModel entry in models)
                {
                    entry.Id = Guid.NewGuid().ToString();
                }
                IEnumerable<TbItem> entrys = models.Select(e => e.ToEntity());
                tbItemService.AddEntrys(entrys.ToList<TbItem>());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Delete()
        {
            var callback = Request.Params["callback"];
            var models = JsonConvert.DeserializeObject<IEnumerable<TbItemModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<TbItem> entrys = models.Select(e => e.ToEntity());
                tbItemService.DeleteEntrys(entrys.ToList<TbItem>());
            }
            return Json(models);
        }
    }
}