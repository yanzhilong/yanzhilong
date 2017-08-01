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
using yanzhilong.Repository;

namespace yanzhilong.Controllers
{
    public class ArticleController : Controller
    {
        private ViewTotalService pcs = new ViewTotalService();
        private ArticleService articleCRUD = new ArticleService();
        private CategoryService categoryCRUD = new CategoryService();
        private UserService userCRUD = new UserService();



        // GET: Article
        public ActionResult Index()
        {
            return List();
        }

        //[Route("Article/List/{page:int}")]
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

        public string ContentGet(string Id)
        {
            Article article = articleCRUD.GetArticleById(Id);
            return article.Content;
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if(Session[id] == null)
            {
                HttpContext.Session.Add(id, id);
                pcs.PageViewDetails(id);
            }
            ViewBag.PageViewCount = pcs.GetViewTotalByResourceID(id);

            Article article = articleCRUD.GetArticleById(id);
            ArticleModel am = article.ToModel();
            ViewBag.PreArticle = articleCRUD.GetPreArticle(article).ToModel();
            ViewBag.NextArticle = articleCRUD.GetNextArticle(article).ToModel();

            am.EditorModel = new EditorModel { Get = Url.Action("ContentGet", "Article"), ParameterId = id };
            return View(am);
        }

        [Route("Article/Category/{CategoryID}")]
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