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
            ActicleViewModel avm = new ActicleViewModel();
            avm.articles = articleCRUD.GetArticles(page, CategoryID != null ? CategoryID : null);
            avm.pvm = articleCRUD.GetPagingViewModel(page, PageHelper.PAGESIZE, CategoryID);
            avm.pvm.actionName = actionName;
            avm.pvm.controllerName = "Article";
            return View("Index", avm);
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