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
    public class CategoryController : BaseAdminController
    {
        private CategoryService categoryCRUD = new CategoryService();

        public ActionResult Index()
        {
            if (!Authorize(PermissionRecordProvider.ManageCategory))
                return AccessDeniedView();

            return View();
        }


        [JsonCallback]
        public ActionResult List()
        {
            if (!Authorize(PermissionRecordProvider.ManageCategory))
                return AuthorizeGrid();

            var categorys = categoryCRUD.GetCategorys();
            IEnumerable<CategoryModel> categoryModels = categorys.Select(x => x.ToModel());

            return Json(categoryModels);
        }

        [JsonCallback]
        public ActionResult Update()
        {
            if (!Authorize(PermissionRecordProvider.ManageCategory))
                return AuthorizeGrid();

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
            if (!Authorize(PermissionRecordProvider.ManageCategory))
                return AuthorizeGrid();

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
            if (!Authorize(PermissionRecordProvider.ManageCategory))
                return AuthorizeGrid();

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