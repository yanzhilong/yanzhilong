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
using yanzhilong.Infrastructure.Mapper;

namespace yanzhilong.Areas.Admin.Controllers
{
    public class ResourceStarController : Controller
    {
        private ProductService productCRUD = new ProductService();
        private ArticleService articleCRUD = new ArticleService();
        private TutorialsService tutorialsCRUD = new TutorialsService();
        private ResourceStarService resourceStarCRUD = new ResourceStarService();
        private UserService userCRUD = new UserService();
        // GET: Tutorials

        public ActionResult Index()
        {
            return List();
        }

        [Route("ResourceStar/List/{page:int}")]
        public ActionResult List(int page = 1)
        {
            PageModel pagemodel = new PageModel(Constant.PAGESIZE, page, resourceStarCRUD.GetCount());
            pagemodel.actionName = "List";
            pagemodel.controllerName = "ResourceStar";
            ViewBag.pagemodel = pagemodel;

            var resourceStars = resourceStarCRUD.GetResourceStars(page);
            IEnumerable<ResourceStarModel> resourceStarModels = resourceStars.Select(x => x.ToModel());

            return View("Index", resourceStarModels);
        }

        // GET: GuestBook/Create
        [Authentication]
        public ActionResult Create()
        {
            ResourceStarModel resourceStarModel = new ResourceStarModel();
            resourceStarModel.ResourceTypeSelectItems = getResourceTypes();
            return View(resourceStarModel);
        }

        // POST: GuestBook/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Create(ResourceStarModel resourceStarModel)
        {
            
            if (ModelState.IsValid)
            {
                resourceStarModel.ResourceID = Guid.NewGuid().ToString();
                ResourceStar resourceStar = resourceStarModel.ToEntity();
                resourceStarCRUD.Create(resourceStar);
                return RedirectToAction("Index");
            }
            resourceStarModel.ResourceTypeSelectItems = getResourceTypes();
            return View(resourceStarModel);
        }

        [Authentication]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResourceStar resourceStar = resourceStarCRUD.GetResourceStarById(id);
            ResourceStarModel resourceStarModel = resourceStar.ToModel();
            resourceStarModel.ResourceTypeSelectItems = getResourceTypes();
            return View(resourceStarModel);
        }
        [ValidateInput(false)]
        [HttpPost]
        [Authentication]
        public ActionResult Edit(ResourceStarModel resourceStarModel)
        {
            if (ModelState.IsValid)
            {
                ResourceStar resourceStar = resourceStarModel.ToEntity();
                resourceStarCRUD.Update(resourceStar);
                return RedirectToAction("Index");
            }
            resourceStarModel.ResourceTypeSelectItems = getResourceTypes();
            return View(resourceStarModel);
        }
        [Authentication]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resourceStarCRUD.Delete(id);
            return RedirectToAction("Index");
        }

        private List<SelectListItem> getResourceTypes()
        {
            IEnumerable<ResourceStarType> rsts = resourceStarCRUD.getResourceStarTypes();
            var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="请选择",Selected=true}
            };
            var selectList = new SelectList(rsts, "ID", "Name");
            selectItemList.AddRange(selectList);
            return selectItemList;
        }

    }
}