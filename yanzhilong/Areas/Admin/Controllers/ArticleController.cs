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
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace yanzhilong.Areas.Admin.Controllers
{
    public class ArticleController : Controller
    {
        private ArticleService articleCRUD = new ArticleService();
        private CategoryService categoryCRUD = new CategoryService();
        private UserService userCRUD = new UserService();

        [Authentication]
        public ActionResult Index()
        {
            ArticleModel articleModel = new ArticleModel();
            articleModel.CategorySelectItems = getCateGorys();
            return View(articleModel);
        }

        [Authentication]
        [JsonCallback]
        public ActionResult List()
        {
            var articles = articleCRUD.GetArticles();
            IEnumerable<ArticleModel> articleModels = articles.Select(x => x.ToModel());
            return Json(articleModels);
        }

        [HttpPost]
        [Authentication]
        [JsonCallback]
        public ActionResult Create()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<ArticleModel>>(Request.Params["models"]);

            if (models != null)
            {
                foreach (ArticleModel model in models)
                {
                    model.Id = Guid.NewGuid().ToString();
                    model.CreateAt = DateTime.Now;
                    string userID = HttpContext.Session["UserID"] as string;
                    model.UserID = userID;
                }
                IEnumerable<Article> entitys = models.Select(e => e.ToEntity());
                articleCRUD.AddEntrys(entitys.ToList<Article>());
            }
            return Json(models);
        }

        [Authentication]
        public string ContentGet(string Id)
        {
            Article article = articleCRUD.GetArticleById(Id);
            return article.Content;
        }

        [ValidateInput(false)]
        [HttpPost]
        [Authentication]
        public JsonResult ContentUpdate(string Id,string MarkDown)
        {
            Article article = articleCRUD.GetArticleById(Id);
            article.Content = MarkDown;
            articleCRUD.Update(article);
            return Json(new { success = true, responseText = "保存成功" }, JsonRequestBehavior.AllowGet);
        }

        [Authentication]
        [JsonCallback]
        public ActionResult Update()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<ArticleModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<Article> entity = models.Select(e => e.ToEntity());
                articleCRUD.UpdateEntrys(entity.ToList<Article>());
            }
            return Json(models);
        }

        [Authentication]
        [JsonCallback]
        public ActionResult Delete()
        {
            var callback = Request.Params["callback"];
            var models = JsonConvert.DeserializeObject<IEnumerable<ArticleModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<Article> entitys = models.Select(e => e.ToEntity());
                articleCRUD.DeleteEntrys(entitys.ToList<Article>());
            }
            return Json(models);
        }

        [Authentication]
        public ActionResult Content(string Id)
        {
            EditorModel editorModel = new EditorModel { Get = Url.Action("ContentGet", "Article"), Post = Url.Action("ContentUpdate", "Article"), ParameterId = Id };
            return View(editorModel);
        }

        [ValidateInput(false)]
        [HttpPost]
        [Authentication]
        public ActionResult Edit(ArticleModel articleModel)
        {
            if (ModelState.IsValid)
            {
                Article article = articleModel.ToEntity();
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
            var selectList = new SelectList(categorys, "Id", "Name");
            selectItemList.AddRange(selectList);
            return selectItemList;
        }

    }
}