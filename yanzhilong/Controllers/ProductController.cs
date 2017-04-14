using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using yanzhilong.Helper;
using yanzhilong.Models;

namespace yanzhilong.Controllers
{
    public class ProductController : Controller
    {
        private ProductCRUD productCRUD = new ProductCRUD();

        // GET: Product
        public ActionResult Index()
        {
            return List();
        }

        [Route("Product/List/{page:int}")]
        public ActionResult List(int page = 1)
        {
            page--;
            ProductViewModel pvm = new ProductViewModel();
            pvm.products = productCRUD.GetProducts(page);
            pvm.pvm = productCRUD.GetPagingViewModel(page, PageHelper.PAGESIZE);
            pvm.pvm.actionName = "List";
            pvm.pvm.controllerName = "Product";
            return View("Index", pvm);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productCRUD.GetProductById(id);
            return View(product);
        }
    }
}