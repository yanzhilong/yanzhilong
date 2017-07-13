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
        private TbPropertyService tbPropertyService = new TbPropertyService();
        private TbPropertyMappingService tbPropertyMappingService = new TbPropertyMappingService();

        [Authentication]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TbPropertyCategoryItems()
        {
            TbPropertyCategoryModel tbPropertyCategoryModel = new TbPropertyCategoryModel();
            return PartialView(tbPropertyCategoryModel);
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
                //先删当前分类下了属性
                foreach(TbPropertyCategory tbPropertyCategory in entrys)
                {
                    List<TbPropertyMapping> tpms = tbPropertyMappingService.GetEntrys(new TbPropertyMapping { tbPropertyCategory = tbPropertyCategory }).ToList<TbPropertyMapping>();
                    IList<TbProperty> tbPropertys = new List<TbProperty>();
                    foreach (TbPropertyMapping tpm in tpms)
                    {
                        tbPropertys.Add(tpm.tbProperty);
                    }
                    tbPropertyService.DeleteEntrys(tbPropertys);//删除属性
                    tbPropertyMappingService.DeleteEntrys(tpms);//删除映射
                }
                //删除分类
                tbPropertyCategoryService.DeleteEntrys(entrys.ToList<TbPropertyCategory>());
            }
            return Json(models);
        }
    }
}