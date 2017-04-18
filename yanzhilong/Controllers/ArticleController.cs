using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using yanzhilong.filter;
using yanzhilong.Helper;
using yanzhilong.Models;

namespace yanzhilong.Controllers
{
    public class ArticleController : Controller
    {
        private ArticleCRUD articleCRUD = new ArticleCRUD();
        private CategoryCRUD categoryCRUD = new CategoryCRUD();
        private UserCRUD userCRUD = new UserCRUD();
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
            ArticlesViewModel avm = new ArticlesViewModel();
            avm.articles = articleCRUD.GetArticles(page, CategoryID != null ? CategoryID : null);
            avm.pvm = articleCRUD.GetPagingViewModel(page, PageHelper.PAGESIZE, CategoryID);
            avm.pvm.actionName = actionName;
            avm.pvm.controllerName = "Article";
            return View("Index", avm);
        }

        public ActionResult ViewModelResult(string actionName, int page = 1, string CategoryID = null)
        {
            page--;
            ArticlesViewModel avm = new ArticlesViewModel();
            avm.articles = articleCRUD.GetArticles(page, CategoryID != null ? CategoryID : null);
            avm.pvm = articleCRUD.GetPagingViewModel(page, PageHelper.PAGESIZE, CategoryID);
            avm.pvm.actionName = actionName;
            avm.pvm.controllerName = "Article";
            return View("Index", avm);
        }

        // GET: GuestBook/Create
        [Authentication]
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
        [Authentication]
        public ActionResult Create( Article article)
        {
            removeRequired();
            if (ModelState.IsValid)
            {
                article.ArticleID = Guid.NewGuid().ToString();
                article.CreateAt = DateTime.Now;
                string userID = HttpContext.Session["UserID"] as string;
                User user = userCRUD.GetUserById(userID);
                article.user = user;
                articleCRUD.Create(article);
                return RedirectToAction("Index");
            }
            //
            return View(article);
        }

        [Authentication]
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
        [Authentication]
        public ActionResult Edit(Article article)
        {
            removeRequired();
            if (ModelState.IsValid)
            {
                article.UpdateAt = DateTime.Now;
                articleCRUD.Update(article);
                return RedirectToAction("Index");
            }
            getCateGorys();
            return View(article);
        }

        private void removeRequired()
        {
            string[] array = new string[] {"user.UserName","user.PasswordHash", "category.Name" };
            foreach (var key in array)
            {
                ModelState.Remove(key);
            }
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

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = articleCRUD.GetArticleById(id);
            ArticleViewModel avm = new ArticleViewModel();
            avm.Current = article;
            avm.Pre = articleCRUD.GetPreArticle(article);
            avm.Next = articleCRUD.GetNextArticle(article);

            return View(avm);
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