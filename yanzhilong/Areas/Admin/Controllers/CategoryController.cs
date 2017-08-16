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
        public ActionResult Index()
        {
            return View();
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
            var models = JsonConvert.DeserializeObject<IEnumerable<CategoryModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<Category> categorys = models.Select(e => e.ToEntity());
                categoryCRUD.Delete(categorys.ToList<Category>());
            }
            return Json(models);
        }
    }
}