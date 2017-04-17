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
    public class ArticleController : Controller
    {
        private ArticleCRUD articleCRUD = new ArticleCRUD();
        private CategoryCRUD categoryCRUD = new CategoryCRUD();
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
            page--;
            ActiclesViewModel avm = new ActiclesViewModel();
            avm.articles = articleCRUD.GetArticles(page, CategoryID != null ? CategoryID : null);
            avm.pvm = articleCRUD.GetPagingViewModel(page, PageHelper.PAGESIZE, CategoryID);
            avm.pvm.actionName = actionName;
            avm.pvm.controllerName = "Article";
            return View("Index", avm);
        }

        public ActionResult ViewModelResult(string actionName, int page = 1, string CategoryID = null)
        {
            page--;
            ActiclesViewModel avm = new ActiclesViewModel();
            avm.articles = articleCRUD.GetArticles(page, CategoryID != null ? CategoryID : null);
            avm.pvm = articleCRUD.GetPagingViewModel(page, PageHelper.PAGESIZE, CategoryID);
            avm.pvm.actionName = actionName;
            avm.pvm.controllerName = "Article";
            return View("Index", avm);
        }

        // GET: GuestBook/Create
        public ActionResult Create()
        {
            getCateGorys();
            return View();
        }

        // POST: GuestBook/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Article article)
        {
            if (ModelState.IsValid)
            {
                article.ArticleID = Guid.NewGuid().ToString();
                article.CreateAt = DateTime.Now;
                User user = new User();
                user.UserID = "1f1c4189-3792-4a91-8d08-c0d04e18a0ae";
                article.user = user;
                articleCRUD.Create(article);
                return RedirectToAction("Index");
            }
            //
            return View(article);
        }


        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = articleCRUD.GetArticleById(id);
            getCateGorys();
            return View(article);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                articleCRUD.Update(article);
                return RedirectToAction("Index");
            }
            getCateGorys();
            return View(article);
        }

        private void getCateGorys()
        {
            IEnumerable<Category> categorys = categoryCRUD.GetCategorys();
            var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="0",Text="请选择",Selected=true}
            };
            var selectList = new SelectList(categorys, "CategoryID", "Name");
            selectItemList.AddRange(selectList);
            ViewBag.categorys = selectItemList;
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
            
            Article article = articleCRUD.GetArticleById(id);
            return View(article);
        }

        [Route("Article/Category/{CategoryID}")]
        [Route("Article/Category/{CategoryID}/{page}")]
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