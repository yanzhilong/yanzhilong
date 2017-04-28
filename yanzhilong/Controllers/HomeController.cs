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
        private TutorialsService tutorialsCRUD = new TutorialsService();
        private ProductService productCRUD = new ProductService();
        private ArticleService articleCRUD = new ArticleService();

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