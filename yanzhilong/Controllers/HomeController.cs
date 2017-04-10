using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yanzhilong.Models;

namespace yanzhilong.Controllers
{
    public class HomeController : Controller
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private TutorialsCRUD tutorialsCRUD = new TutorialsCRUD();
        
        public ActionResult Index()
        {
            IList<Tutorials> tutorialses = tutorialsCRUD.GetTutorialses();
            logger.Info("index");
            return View();
        }
    }
}