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
    public class ProductController : Controller
    {
        private ProductService productCRUD = new ProductService();

        // GET: Product
        public ActionResult Index()
        {
            return List();
        }

        //[Route("Product/List/{page:int}")]
        public ActionResult List(int page = 1)
        {
            PageModel pagemodel = new PageModel(Constant.PAGESIZE, page, productCRUD.GetCount());
            pagemodel.actionName = "List";
            pagemodel.controllerName = "Product";
            ViewBag.pagemodel = pagemodel;

            var products = productCRUD.GetProducts(page);
            IEnumerable<ProductModel> productModels = products.Select(x => x.ToModel());

            return View("Index", productModels);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productCRUD.GetProductById(id);
            return View(product.ToModel());
        }
    }
}