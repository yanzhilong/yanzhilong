using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yanzhilong.Domain;
using yanzhilong.Models;
using yanzhilong.Service;

namespace yanzhilong.Controllers
{
    public class HomeController : Controller
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ArticleService articleCRUD = new ArticleService();
        private FilePersistenceService filePersistenceService = new FilePersistenceService();

        public ActionResult Index()
        {
            List<String> homeimgs = filePersistenceService.HomeImages();
            ViewBag.list = homeimgs;
            return View();
        }
    }
}