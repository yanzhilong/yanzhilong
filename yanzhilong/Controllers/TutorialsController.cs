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
        private PageViewCountService pcs = new PageViewCountService();
        private TutorialsService tutorialsCRUD = new TutorialsService();
        private UserService userCRUD = new UserService();

        public ActionResult Index()
        {
            return List();
        }

        public ActionResult List(int page = 1)
        {
            PageModel pagemodel = new PageModel(Constant.PAGESIZE, page, tutorialsCRUD.GetCount());
            pagemodel.actionName = "List";
            pagemodel.controllerName = "Tutorials";
            ViewBag.pagemodel = pagemodel;

            var tutorials = tutorialsCRUD.GetTutorialses(page);
            IEnumerable<TutorialsModel> tutorialsModels = tutorials.Select(x => x.ToModel());

            return View("Index", tutorialsModels);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Session[id] == null)
            {
                HttpContext.Session.Add(id, id);
                pcs.PageViewDetails(id);
            }
            ViewBag.PageViewCount = pcs.GetPageViewCountByResourceID(id);
            Tutorials tutorials = tutorialsCRUD.GetTutorialsById(id);
            return View(tutorials.ToModel());
        }
    }
}