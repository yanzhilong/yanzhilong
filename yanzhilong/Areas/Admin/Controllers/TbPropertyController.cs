﻿using System;
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

        [Authentication]
        public ActionResult Index(string TbPropertyCategoryId)
        {
            TbProperty entry = new TbProperty() { tbPropertyCategory = new TbPropertyCategory { Id = TbPropertyCategoryId } };
            if(TbPropertyCategoryId != null)
            {
                TbPropertyCategory entrycategory = tbPropertyCategoryService.GetEntry(new TbPropertyCategory { Id = TbPropertyCategoryId });
                ViewBag.TbPropertyCategory = entrycategory.ToModel();
            }

            return View(entry.ToModel());
        }

        [JsonCallback]
        public ActionResult List(string TbPropertyCategoryId)
        {
            TbProperty entry = new TbProperty { tbPropertyCategory = new TbPropertyCategory { Id = TbPropertyCategoryId } };
            var entrys = tbPropertyService.GetEntrys(entry);
            IEnumerable<TbPropertyModel> entrymodels = entrys.Select(x => x.ToModel());
            return Json(entrymodels);
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