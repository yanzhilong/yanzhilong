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
    public class TbPropertyController : Controller
    {
        private TbPropertyService tbPropertyService = new TbPropertyService();
        private TbPropertyCategoryService tbPropertyCategoryService = new TbPropertyCategoryService();
        private TbPropertyMappingService tbPropertyMappingService = new TbPropertyMappingService();

        [Authentication]
        public ActionResult Index()
        {
            TbProperty entry = new TbProperty();
            return View(entry.ToModel());
        }

        [JsonCallback]
        public ActionResult List()
        {
            TbProperty entry = new TbProperty();
            var entrys = tbPropertyService.GetEntrys(entry);
            IEnumerable<TbPropertyModel> entrymodels = entrys.Select(x => x.ToModel());
            return Json(entrymodels);
        }

        
        public ActionResult PropertyMapping(string TbPropertyCategoryId)
        {
            TbPropertyMapping tpm = new TbPropertyMapping();
            tpm.tbPropertyCategory = new TbPropertyCategory { Id = TbPropertyCategoryId };
            return View(tpm.ToModel());
        }


        /// <summary>
        /// 得到属性分类关联的属性列表
        /// </summary>
        /// <param name="TbPropertyCategoryId"></param>
        /// <returns></returns>
        [JsonCallback]
        public ActionResult PropertyMappingList(string TbPropertyCategoryId)
        {
            List<TbPropertyMapping> tpms = tbPropertyMappingService.GetEntrys(new TbPropertyMapping { tbPropertyCategory = new TbPropertyCategory { Id = TbPropertyCategoryId } }).ToList<TbPropertyMapping>();
            List<TbProperty> tps = new List<TbProperty>();
            foreach (TbPropertyMapping tpm in tpms)
            {
                TbProperty tp = tbPropertyService.GetEntry(tpm.tbProperty);
                tps.Add(tp);
            }
            IEnumerable<TbPropertyModel> entrymodels = tps.Select(x => x.ToModel());
            return Json(entrymodels);
        }

        /// <summary>
        /// 为属性分类添加属性列表
        /// </summary>
        /// <param name="TbPropertyCategoryId"></param>
        /// <param name="PropertyIds"></param>
        /// <returns></returns>
        [JsonCallback]
        [HttpPost]
        public ActionResult CreatePropertyMappingList(string TbPropertyCategoryId, List<string> PropertyIds)
        {
            List<TbPropertyMapping> tpms = new List<TbPropertyMapping>();
            foreach(string id in PropertyIds)
            {
                TbPropertyMapping tpmexits = tbPropertyMappingService.GetEntry(new TbPropertyMapping { tbProperty = new TbProperty { Id = id },tbPropertyCategory = new TbPropertyCategory { Id = TbPropertyCategoryId } } );
                if (tpmexits != null)
                {
                    continue;
                }
                TbPropertyMapping tpm = new TbPropertyMapping();
                tpm.Id = Guid.NewGuid().ToString();
                tpm.tbProperty = new TbProperty { Id = id };
                tpm.tbPropertyCategory = new TbPropertyCategory { Id = TbPropertyCategoryId };
                tpms.Add(tpm);
            }
            tbPropertyMappingService.AddEntrys(tpms);
            return Json(new { success = true, responseText = "添加成功" }, JsonRequestBehavior.AllowGet);//设置返回值，并允许get请求
        }

        //删除属性分类关联淘宝属性
        [JsonCallback]
        public ActionResult DeletePropertyMappingList(string TbPropertyCategoryId)
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<TbPropertyModel>>(Request.Params["models"]);
            if (models != null)
            {
                List<TbPropertyMapping> tpms = new List<TbPropertyMapping>();
                IEnumerable<TbProperty> entrys = models.Select(e => e.ToEntity());
                foreach(TbProperty tp in entrys)
                {
                    TbPropertyMapping tpm = new TbPropertyMapping();
                    tpm.tbProperty = tp;
                    tpm.tbPropertyCategory = new TbPropertyCategory { Id = TbPropertyCategoryId };
                    TbPropertyMapping tpmnew = tbPropertyMappingService.GetEntry(tpm);
                    if(tpmnew != null)
                    {
                        tpms.Add(tpmnew);
                    }
                }
                tbPropertyMappingService.DeleteEntrys(tpms);
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Update()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<TbPropertyModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<TbProperty> entrys = models.Select(e => e.ToEntity());
                tbPropertyService.UpdateEntrys(entrys.ToList<TbProperty>());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Create()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<TbPropertyModel>>(Request.Params["models"]);

            if (models != null)
            {
                foreach (TbPropertyModel entry in models)
                {
                    entry.Id = Guid.NewGuid().ToString();
                }
                IEnumerable<TbProperty> entrys = models.Select(e => e.ToEntity());
                tbPropertyService.AddEntrys(entrys.ToList<TbProperty>());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Delete()
        {
            var callback = Request.Params["callback"];
            var models = JsonConvert.DeserializeObject<IEnumerable<TbPropertyModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<TbProperty> entrys = models.Select(e => e.ToEntity());
                tbPropertyService.DeleteEntrys(entrys.ToList<TbProperty>());
            }
            return Json(models);
        }
    }
}