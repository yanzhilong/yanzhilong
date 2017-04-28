using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using yanzhilong.filter;
using yanzhilong.Helper;
using yanzhilong.Domain;
using yanzhilong.Models;
using yanzhilong.Service;

namespace yanzhilong.Controllers
{
    public class ResourceStarController : Controller
    {
        private ProductService productCRUD = new ProductService();
        private ArticleService articleCRUD = new ArticleService();
        private TutorialsService tutorialsCRUD = new TutorialsService();
        private ResourceStarService resourceStarCRUD = new ResourceStarService();
        private UserService userCRUD = new UserService();
        // GET: Tutorials
        //public ActionResult Index()
        //{
        //    IList<Tutorials> tutorialses = tutorialsCRUD.GetTutorialses();
        //    return View(tutorialses);
        //}

        public ActionResult Index()
        {
            return List();
        }

        [Route("ResourceStar/List/{page:int}")]
        public ActionResult List(int page = 1)
        {
            page--;
            ResourceStarViewModel rsvm = new ResourceStarViewModel();
            rsvm.resourceStars = resourceStarCRUD.GetResourceStars(page);
            rsvm.pvm = resourceStarCRUD.GetPagingViewModel(page, PageHelper.PAGESIZE);
            rsvm.pvm.actionName = "List";
            rsvm.pvm.controllerName = "ResourceStar";
            return View("Index", rsvm);
        }

        // GET: GuestBook/Create
        [Authentication]
        public ActionResult Create()
        {
            getResourceTypes();
            return View();
        }

        // POST: GuestBook/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Create(ResourceStar resourceStar)
        {
            
            if (ModelState.IsValid)
            {
                resourceStar.ResourceID = Guid.NewGuid().ToString();
                //判断各个id是否存在
                //略
                resourceStarCRUD.Create(resourceStar);
                return RedirectToAction("Index");
            }
            return View(resourceStar);
        }

        [Authentication]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceStar resourceStar = resourceStarCRUD.GetResourceStarById(id);
            getResourceTypes();
            return View(resourceStar);
        }
        [ValidateInput(false)]
        [HttpPost]
        [Authentication]
        public ActionResult Edit(ResourceStar resourceStar)
        {
            if (ModelState.IsValid)
            {
                //判断各个id是否存在
                //略
                resourceStarCRUD.Update(resourceStar);
                return RedirectToAction("Index");
            }
            return View(resourceStar);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resourceStarCRUD.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceStar resourceStar = resourceStarCRUD.GetResourceStarById(id);
            return View(resourceStar);
        }

        private void getResourceTypes()
        {
            IEnumerable<ResourceStarType> rsts = resourceStarCRUD.getResourceStarTypes();
            var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="0",Text="请选择",Selected=true}
            };
            var selectList = new SelectList(rsts, "ID", "Name");
            selectItemList.AddRange(selectList);
            ViewBag.resourceStarTypes = selectItemList;
        }
    }
}