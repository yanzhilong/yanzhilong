using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using yanzhilong.Models;

namespace yanzhilong.Controllers
{
    public class ArticleController : Controller
    {
        private ArticleCRUD articleCRUD = new ArticleCRUD();
        // GET: Article
        public ActionResult Index()
        {
            IList<Article> articles = articleCRUD.GetArticles();
            return View(articles);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = articleCRUD.GetArticleById(id);
            return View(article);
        }

        public ActionResult Category(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IList<Article> articles = articleCRUD.GetArticlesByCategoryId(id);
            return View(articles);
        }
    }
}