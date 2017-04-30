using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yanzhilong.filter;
using yanzhilong.Helper;
using yanzhilong.Domain;
using yanzhilong.Service;
using yanzhilong.Models;

namespace yanzhilong.Controllers
{
    public class ManageController : Controller
    {
        private ArticleService articleCRUD = new ArticleService();
        private TutorialsService tutorialsCRUD = new TutorialsService();
        private ProductService productCRUD = new ProductService();
        private CategoryService categoryCRUD = new CategoryService();
        private ResourceStarService resourceStarCRUD = new ResourceStarService();
        // GET: Manager
        [Authentication]
        public ActionResult Index()
        {
            return View();
        }

        [Authentication]
        public ActionResult Manage()
        {
            return View();
        }

        [Authentication]
        public ActionResult Article(int page = 1)
        {
            page--;
            ArticlesViewModel avm = new ArticlesViewModel();
            avm.articles = articleCRUD.GetArticles(page, null);
            PageModel pagemodel = new PageModel(Constant.PAGESIZE, page, articleCRUD.GetCount());
            avm.pvm = pagemodel;
            avm.pvm.actionName = "Article";
            avm.pvm.controllerName = "Manage";
            return View(avm);
        }

        [Authentication]
        public ActionResult Category(int page = 1)
        {
            //page--;
            //CategorysViewModel cvm = new CategorysViewModel();
            //cvm.categorys = categoryCRUD.GetCategorys(page);
            //cvm.pvm = categoryCRUD.GetPagingViewModel(page, PageHelper.PAGESIZE);
            //cvm.pvm.actionName = "Category";
            //cvm.pvm.controllerName = "Manage";
            return View();
        }

        [Authentication]
        public ActionResult Tutorials(int page = 1)
        {
            //page--;
            //TutorialsesViewModel tvm = new TutorialsesViewModel();
            //tvm.tutorials = tutorialsCRUD.GetTutorialses(page);
            //tvm.pvm = tutorialsCRUD.GetPagingViewModel(page, PageHelper.PAGESIZE);
            //tvm.pvm.actionName = "Tutorials";
            //tvm.pvm.controllerName = "Manage";
            return View();
        }

        [Authentication]
        public ActionResult Product(int page = 1)
        {
            //page--;
            //ProductsViewModel pvm = new ProductsViewModel();
            //pvm.products = productCRUD.GetProducts(page);
            //pvm.pvm = productCRUD.GetPagingViewModel(page, PageHelper.PAGESIZE);
            //pvm.pvm.actionName = "Product";
            //pvm.pvm.controllerName = "Manage";
            return View();
        }

        [Authentication]
        public ActionResult ResourceStar(int page = 1)
        {
            //page--;
            //ResourceStarViewModel rsvm = new ResourceStarViewModel();
            //rsvm.resourceStars = resourceStarCRUD.GetResourceStars(page);
            //rsvm.pvm = resourceStarCRUD.GetPagingViewModel(page, PageHelper.PAGESIZE);
            //rsvm.pvm.actionName = "ResourceStar";
            //rsvm.pvm.controllerName = "Manage";
            return View();
        }
        
    }
}