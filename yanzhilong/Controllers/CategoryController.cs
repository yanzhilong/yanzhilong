using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using yanzhilong.Models;

namespace yanzhilong.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryCRUD categoryCRUD = new CategoryCRUD();

        public ActionResult SideBar()
        {
            IList<ActicleCount> acticleCounts = categoryCRUD.GetArticlesCountGroupByCategory();
            return PartialView("CategorySide", acticleCounts);
        }

        // GET: GuestBook/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GuestBook/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                category.CategoryID = Guid.NewGuid().ToString();
                categoryCRUD.Create(category);
                return RedirectToAction("Index");
            }
            //
            return View(category);
        }


        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryCRUD.GetCategoryById(id);
            return View(category);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryCRUD.Update(category);
                return RedirectToAction("SideBar");
            }
            return View(category);
        }
    }
}