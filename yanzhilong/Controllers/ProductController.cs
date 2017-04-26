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
            ProductsViewModel pvm = new ProductsViewModel();
            pvm.products = productCRUD.GetProducts(page);
            pvm.pvm = productCRUD.GetPagingViewModel(page, PageHelper.PAGESIZE);
            pvm.pvm.actionName = "List";
            pvm.pvm.controllerName = "Product";
            return View("Index", pvm);
        }

        // GET: GuestBook/Create
        [Authentication]
        public ActionResult Create()
        {
            return View();
        }

        // POST: GuestBook/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.ProductID = Guid.NewGuid().ToString();
                product.CreateAt = DateTime.Now;
                User user = new User();
                productCRUD.Create(product);
                return RedirectToAction("Index");
            }
            //
            return View(product);
        }

        [Authentication]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productCRUD.GetProductById(id);
            return View(product);
        }

        [ValidateInput(false)]
        [HttpPost]
        [Authentication]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productCRUD.Update(product);
                return RedirectToAction("Index");
            }
            return View(product);
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