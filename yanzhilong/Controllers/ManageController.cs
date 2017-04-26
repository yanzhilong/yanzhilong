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
        private ArticleCRUD articleCRUD = new ArticleCRUD();
        private TutorialsCRUD tutorialsCRUD = new TutorialsCRUD();
        private ProductCRUD productCRUD = new ProductCRUD();
        private CategoryCRUD categoryCRUD = new CategoryCRUD();
        private ResourceStarCRUD resourceStarCRUD = new ResourceStarCRUD();
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
            avm.pvm = articleCRUD.GetPagingViewModel(page, PageHelper.PAGESIZE,null);
            avm.pvm.actionName = "Article";
            avm.pvm.controllerName = "Manage";
            return View(avm);
        }

        [Authentication]
        public ActionResult Category(int page = 1)
        {
            page--;
            CategorysViewModel cvm = new CategorysViewModel();
            cvm.categorys = categoryCRUD.GetCategorys(page);
            cvm.pvm = categoryCRUD.GetPagingViewModel(page, PageHelper.PAGESIZE);
            cvm.pvm.actionName = "Category";
            cvm.pvm.controllerName = "Manage";
            return View(cvm);
        }

        [Authentication]
        public ActionResult Tutorials(int page = 1)
        {
            page--;
            TutorialsesViewModel tvm = new TutorialsesViewModel();
            tvm.tutorials = tutorialsCRUD.GetTutorialses(page);
            tvm.pvm = tutorialsCRUD.GetPagingViewModel(page, PageHelper.PAGESIZE);
            tvm.pvm.actionName = "Tutorials";
            tvm.pvm.controllerName = "Manage";
            return View(tvm);
        }

        [Authentication]
        public ActionResult Product(int page = 1)
        {
            page--;
            ProductsViewModel pvm = new ProductsViewModel();
            pvm.products = productCRUD.GetProducts(page);
            pvm.pvm = productCRUD.GetPagingViewModel(page, PageHelper.PAGESIZE);
            pvm.pvm.actionName = "Product";
            pvm.pvm.controllerName = "Manage";
            return View(pvm);
        }

        [Authentication]
        public ActionResult ResourceStar(int page = 1)
        {
            page--;
            ResourceStarViewModel rsvm = new ResourceStarViewModel();
            rsvm.resourceStars = resourceStarCRUD.GetResourceStars(page);
            rsvm.pvm = resourceStarCRUD.GetPagingViewModel(page, PageHelper.PAGESIZE);
            rsvm.pvm.actionName = "ResourceStar";
            rsvm.pvm.controllerName = "Manage";
            return View(rsvm);
        }
        
    }
}