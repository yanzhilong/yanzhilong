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

       

        // GET: GuestBook/Create
        [Authentication]
        public ActionResult Create()
        { 
            CategoryModel dategoryModel = new CategoryModel();
            return View(dategoryModel);
        }

        // POST: GuestBook/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Create(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                categoryModel.Id = Guid.NewGuid().ToString();
                Category category = categoryModel.ToEntity();
                categoryCRUD.Create(category);
                return RedirectToAction("Index");
            }
            //
            return View(categoryModel);
        }

        [Authentication]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryCRUD.GetCategoryById(id);
            CategoryModel categoryModel = category.ToModel();

            return View(categoryModel);
            
        }
        [ValidateInput(false)]
        [HttpPost]
        [Authentication]
        public ActionResult Edit(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                Category category = categoryModel.ToEntity();
                categoryCRUD.Update(category);
                return RedirectToAction("Index");
            }
            return View(categoryModel);
        }
        [Authentication]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            categoryCRUD.Delete(id);
            return RedirectToAction("Index");
        }
    }
}