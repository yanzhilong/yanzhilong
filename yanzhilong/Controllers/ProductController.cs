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

        [Route("Product/List/{page:int}")]
        public ActionResult List(int page = 1)
        {
            PageModel pagemodel = new PageModel(PageHelper.PAGESIZE, page, productCRUD.GetCount());
            pagemodel.actionName = "List";
            pagemodel.controllerName = "Product";
            ViewBag.pagemodel = pagemodel;

            var products = productCRUD.GetProducts(page);
            IEnumerable<ProductModel> productModels = products.Select(x => x.ToModel());

            return View("Index", productModels);
        }

        // GET: GuestBook/Create
        [Authentication]
        public ActionResult Create()
        {
            ProductModel productModel = new ProductModel();
            return View(productModel);
        }

        // POST: GuestBook/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Create(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                productModel.ProductID = Guid.NewGuid().ToString();
                productModel.CreateAt = DateTime.Now;
                Product product = productModel.ToEntity();
                productCRUD.Create(product);
                return RedirectToAction("Index");

            }
            //
            return View(productModel);
        }

        [Authentication]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productCRUD.GetProductById(id);
            ProductModel productModel = product.ToModel();

            return View(productModel);
        }

        [ValidateInput(false)]
        [HttpPost]
        [Authentication]
        public ActionResult Edit(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                Product product = productModel.ToEntity();
                productCRUD.Update(product);
                return RedirectToAction("Index");
            }
            return View(productModel);
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