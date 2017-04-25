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
        private ProductCRUD productCRUD = new ProductCRUD();
        private ArticleCRUD articleCRUD = new ArticleCRUD();

        public ActionResult Index()
        {
            IList<Tutorials> tutorialses = tutorialsCRUD.GetStarTutorialses();
            IList<Product> products = productCRUD.GetStarProducts();
            IList<Article> articles = articleCRUD.GetStarArticles();
            HomeViewModel hv = new HomeViewModel();
            hv.products = products;
            hv.tutorials = tutorialses;
            hv.articles = articles;
            logger.Info("index");
            return View(hv);
        }
    }
}