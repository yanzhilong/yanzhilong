using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using yanzhilong.Models;

namespace yanzhilong.Controllers
{
    public class TutorialsController : Controller
    {
        private TutorialsCRUD tutorialsCRUD = new TutorialsCRUD();
        // GET: Tutorials
        public ActionResult Index()
        {
            IList<Tutorials> tutorialses = tutorialsCRUD.GetTutorialses();
            return View(tutorialses);
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