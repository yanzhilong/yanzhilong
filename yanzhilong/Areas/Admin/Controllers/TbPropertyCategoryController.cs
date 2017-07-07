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
    public class TbPropertyCategoryController : Controller
    {
        private TbPropertyCategoryService tbPropertyCategoryService = new TbPropertyCategoryService();

        [Authentication]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TbPropertyCategoryItems()
        {
            TbPropertyCategoryModel tbPropertyCategoryModel = new TbPropertyCategoryModel();
            tbPropertyCategoryModel.TbPropertyCategoryItems = getTbPropertyCategoryItems();
            return PartialView(tbPropertyCategoryModel);
        }

        private List<SelectListItem> getTbPropertyCategoryItems()
        {
            IEnumerable<TbPropertyCategory> tbPropertyCategorys = tbPropertyCategoryService.GetEntrys(new TbPropertyCategory());
            var selectItemList = new List<SelectListItem>();
            var selectList = new SelectList(tbPropertyCategorys, "Id", "Name");
            selectItemList.AddRange(selectList);
            return selectItemList;
        }

        [JsonCallback]
        public ActionResult List()
        {
            var entrys = tbPropertyCategoryService.GetEntrys(null);
            IEnumerable<TbPropertyCategoryModel> entrymodels = entrys.Select(x => x.ToModel());
            return Json(entrymodels);
        }

        [JsonCallback]
        public ActionResult Update()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<TbPropertyCategoryModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<TbPropertyCategory> entrys = models.Select(e => e.ToEntity());
                tbPropertyCategoryService.UpdateEntrys(entrys.ToList <TbPropertyCategory > ());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Create()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<TbPropertyCategoryModel>>(Request.Params["models"]);

            if (models != null)
            {
                foreach (TbPropertyCategoryModel entry in models)
                {
                    entry.Id = Guid.NewGuid().ToString();
                }
                IEnumerable<TbPropertyCategory> entrys = models.Select(e => e.ToEntity());
                tbPropertyCategoryService.AddEntrys(entrys.ToList<TbPropertyCategory>());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Delete()
        {
            var callback = Request.Params["callback"];
            var models = JsonConvert.DeserializeObject<IEnumerable<TbPropertyCategoryModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<TbPropertyCategory> entrys = models.Select(e => e.ToEntity());
                tbPropertyCategoryService.DeleteEntrys(entrys.ToList<TbPropertyCategory>());
            }
            return Json(models);
        }
    }
}