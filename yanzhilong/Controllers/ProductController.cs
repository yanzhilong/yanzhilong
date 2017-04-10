using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using yanzhilong.Models;

namespace yanzhilong.Controllers
{
    public class ProductController : Controller
    {
        private ProductCRUD productCRUD = new ProductCRUD();
        // GET: Product
        public ActionResult Index()
        {
            IList<Product> products = productCRUD.GetProducts();
            return View(products);
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