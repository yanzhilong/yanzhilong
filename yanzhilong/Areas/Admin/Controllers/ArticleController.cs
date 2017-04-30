using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using yanzhilong.filter;
using yanzhilong.Helper;
using yanzhilong.Infrastructure.Mapper;
using yanzhilong.Domain;
using yanzhilong.Service;
using yanzhilong.Models;

namespace yanzhilong.Areas.Admin.Controllers
{
    public class ArticleController : Controller
    {
        private ArticleService articleCRUD = new ArticleService();
        private CategoryService categoryCRUD = new CategoryService();
        private UserService userCRUD = new UserService();
        // GET: Article
        public ActionResult Index()
        {
            return List();
        }

        [Route("Article/List/{page:int}")]
        public ActionResult List(int page = 1, string CategoryID = null)
        {
            return Result("List", page, CategoryID);
        }

        public ActionResult Result(string actionName,int page = 1, string CategoryID = null)
        {
            PageModel pagemodel = new PageModel(Constant.PAGESIZE, page, articleCRUD.GetCount(CategoryID));
            pagemodel.actionName = actionName;
            pagemodel.controllerName = "Article";
            ViewBag.pagemodel = pagemodel;

            var articles = articleCRUD.GetArticles(page, CategoryID);
            IEnumerable<ArticleModel> articleModels = articles.Select(x => x.ToModel());
            
            return View("Index", articleModels);
        }

        // GET: GuestBook/Create
        [Authentication]
        public ActionResult Create()
        {
            ArticleModel articleModel = new ArticleModel();
            articleModel.CategorySelectItems = getCateGorys();
            return View(articleModel);
        }

        // GET: GuestBook/Create
        public ActionResult CreateNew()
        {
            ArticleModel articleModel = new ArticleModel();
            articleModel.CategorySelectItems = getCateGorys();
            return View(articleModel);
        }


        // POST: GuestBook/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public ActionResult Create( ArticleModel articleModel)
        {
            if (ModelState.IsValid)
            {
                articleModel.ArticleID = Guid.NewGuid().ToString();
                articleModel.CreateAt = DateTime.Now;
                string userID = HttpContext.Session["UserID"] as string;
                articleModel.UserID = userID;
                Article article = articleModel.ToEntity();
                articleCRUD.Create(article);
                return RedirectToAction("Index");
            }
            return View(articleModel);
        }

        [Authentication]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = articleCRUD.GetArticleById(id);
            ArticleModel articleModel = article.ToModel();
            articleModel.CategorySelectItems = getCateGorys();
            return View(articleModel);
        }
        [ValidateInput(false)]
        [HttpPost]
        [Authentication]
        public ActionResult Edit(ArticleModel articleModel)
        {
            if (ModelState.IsValid)
            {
                Article article = articleModel.ToEntity();
                article.UpdateAt = DateTime.Now;
                articleCRUD.Update(article);
                return RedirectToAction("Index");
            }
            articleModel.CategorySelectItems = getCateGorys();
            return View(articleModel);
        }

        private List<SelectListItem> getCateGorys()
        {
            IEnumerable<Category> categorys = categoryCRUD.GetCategorys();
            var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="请选择",Selected=true}
            };
            var selectList = new SelectList(categorys, "CategoryID", "Name");
            selectItemList.AddRange(selectList);
            return selectItemList;
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articleCRUD.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(string id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = articleCRUD.GetArticleById(id);
            ArticleModel am = article.ToModel();
            ViewBag.PreArticle = articleCRUD.GetPreArticle(article).ToModel();
            ViewBag.NextArticle = articleCRUD.GetNextArticle(article).ToModel();
            return View(am);
        }

        //[Route("Article/Category/{CategoryID}")]
        //[Route("Article/Category/{CategoryID}/{page}")]
        public ActionResult Category(int page = 1, string CategoryID = null)
        {
            if (CategoryID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return Result("Category", page, CategoryID);
        }

        
    }
}