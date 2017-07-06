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
    public class CategoryController : Controller
    {
        private CategoryService categoryCRUD = new CategoryService();
        [Authentication]
        public ActionResult Index(int page = 1)
        {
            PageModel pagemodel = new PageModel(Constant.PAGESIZE, page, categoryCRUD.GetCount());
            pagemodel.actionName = "Index";
            pagemodel.controllerName = "Category";
            ViewBag.pagemodel = pagemodel;

            var categorys = categoryCRUD.GetCategorys(page);
            IEnumerable<CategoryModel> categoryModels = categorys.Select(x => x.ToModel());
            return View(categoryModels);
        }


        [JsonCallback]
        public ActionResult List()
        {
            var categorys = categoryCRUD.GetCategorys();
            IEnumerable<CategoryModel> categoryModels = categorys.Select(x => x.ToModel());

            return Json(categoryModels);
        }

        [JsonCallback]
        public ActionResult Update()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<CategoryModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<Category> categorys = models.Select(e => e.ToEntity());
                categoryCRUD.Update(categorys.ToList<Category>());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Create()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<CategoryModel>>(Request.Params["models"]);

            if (models != null)
            {
                foreach (CategoryModel category in models)
                {
                    category.Id = Guid.NewGuid().ToString();
                }
                IEnumerable<Category> categorys = models.Select(e => e.ToEntity());
                categoryCRUD.Create(categorys.ToList<Category>());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Delete()
        {
            var callback = Request.Params["callback"];
            var models = JsonConvert.DeserializeObject<IEnumerable<CategoryModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<Category> categorys = models.Select(e => e.ToEntity());
                categoryCRUD.Delete(categorys.ToList<Category>());
            }
            return Json(models);
            //return new JsonpResult<object>(models, callback);
        }
    }
}