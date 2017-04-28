﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using yanzhilong.filter;
using yanzhilong.Helper;
using yanzhilong.Domain;
using yanzhilong.Service;
using yanzhilong.Models;

namespace yanzhilong.Controllers
{
    public class TutorialsController : Controller
    {
        private TutorialsService tutorialsCRUD = new TutorialsService();
        private UserService userCRUD = new UserService();
        // GET: Tutorials
        //public ActionResult Index()
        //{
        //    IList<Tutorials> tutorialses = tutorialsCRUD.GetTutorialses();
        //    return View(tutorialses);
        //}

        public ActionResult Index()
        {
            return List();
        }

        [Route("Tutorials/List/{page:int}")]
        public ActionResult List(int page = 1)
        {
            page--;
            TutorialsesViewModel tvm = new TutorialsesViewModel();
            tvm.tutorials = tutorialsCRUD.GetTutorialses(page);
            tvm.pvm = tutorialsCRUD.GetPagingViewModel(page, PageHelper.PAGESIZE);
            tvm.pvm.actionName = "List";
            tvm.pvm.controllerName = "Tutorials";
            return View("Index", tvm);

            
        }

        // GET: GuestBook/Create
        [Authentication]
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
        [Authentication]
        public ActionResult Create(Tutorials tutorials)
        {
            removeRequired();
            if (ModelState.IsValid)
            {
                tutorials.TutorialsID = Guid.NewGuid().ToString();
                tutorials.CreateAt = DateTime.Now;
                string userID = HttpContext.Session["UserID"] as string;
                User user = userCRUD.GetUserById(userID);
                tutorials.user = user;
                tutorialsCRUD.Create(tutorials);
                return RedirectToAction("Index");
            }
            //
            return View(tutorials);
        }

        [Authentication]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutorials tutorials = tutorialsCRUD.GetTutorialsById(id);
            return View(tutorials);
        }
        [ValidateInput(false)]
        [HttpPost]
        [Authentication]
        public ActionResult Edit(Tutorials tutorials)
        {
            removeRequired();
            if (ModelState.IsValid)
            {
                tutorials.UpdateAt = DateTime.Now;
                tutorialsCRUD.Update(tutorials);
                return RedirectToAction("Index");
            }
            return View(tutorials);
        }

        private void removeRequired()
        {
            string[] array = new string[] { "user.UserName", "user.PasswordHash" };
            foreach (var key in array)
            {
                ModelState.Remove(key);
            }
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutorials tutorials = tutorialsCRUD.GetTutorialsById(id);
            return View(tutorials);
        }
    }
}