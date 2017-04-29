using System;
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
using yanzhilong.Infrastructure.Mapper;

namespace yanzhilong.Controllers
{
    public class TutorialsController : Controller
    {
        private TutorialsService tutorialsCRUD = new TutorialsService();
        private UserService userCRUD = new UserService();

        public ActionResult Index()
        {
            return List();
        }

        [Route("Tutorials/List/{page:int}")]
        public ActionResult List(int page = 1)
        {
            PageModel pagemodel = new PageModel(PageHelper.PAGESIZE, page, tutorialsCRUD.GetCount());
            pagemodel.actionName = "List";
            pagemodel.controllerName = "Tutorials";
            ViewBag.pagemodel = pagemodel;

            var tutorials = tutorialsCRUD.GetTutorialses(page);
            IEnumerable<TutorialsModel> tutorialsModels = tutorials.Select(x => x.ToModel());

            return View("Index", tutorialsModels);
        }

        // GET: GuestBook/Create
        [Authentication]
        public ActionResult Create()
        {
            TutorialsModel tutorialsModel = new TutorialsModel();
            return View(tutorialsModel);
        }

        // POST: GuestBook/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Create(TutorialsModel tutorialsModel)
        {
            if (ModelState.IsValid)
            {
                tutorialsModel.TutorialsID = Guid.NewGuid().ToString();
                tutorialsModel.CreateAt = DateTime.Now;
                string userID = HttpContext.Session["UserID"] as string;
                tutorialsModel.UserID = userID;
                Tutorials tutorials = tutorialsModel.ToEntity();
                tutorialsCRUD.Create(tutorials);
                return RedirectToAction("Index");
            }
            return View(tutorialsModel);
        }

        [Authentication]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutorials tutorials = tutorialsCRUD.GetTutorialsById(id);
            TutorialsModel tutorialsModel = tutorials.ToModel();
            
            return View(tutorialsModel);
        }

        [ValidateInput(false)]
        [HttpPost]
        [Authentication]
        public ActionResult Edit(TutorialsModel tutorialsModel)
        {
            if (ModelState.IsValid)
            {
                Tutorials tutorials = tutorialsModel.ToEntity();
                tutorialsCRUD.Update(tutorials);
                return RedirectToAction("Index");
            }
            return View(tutorialsModel);
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