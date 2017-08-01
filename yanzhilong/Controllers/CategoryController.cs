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

namespace yanzhilong.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService categoryCRUD;

        public CategoryController(CategoryService categoryService)
        {
            categoryCRUD = categoryService;
        }

        public ActionResult SideBar()
        {
            IList<ArticleCount> acticleCounts = categoryCRUD.GetArticlesCountGroupByCategory();
            return PartialView("CategorySide", acticleCounts);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryCRUD.GetCategoryById(id);
            CategoryModel cm = category.ToModel();
            return View(cm);
        }

    }
}