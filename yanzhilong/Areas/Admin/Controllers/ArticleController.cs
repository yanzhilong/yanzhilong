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
using yanzhilong.Security;
using yanzhilong.Domain.Kendo;

namespace yanzhilong.Areas.Admin.Controllers
{
    public class ArticleController : BaseAdminController
    {
        private readonly ArticleService _ArticleService;
        private readonly CategoryService _CategoryService;
        private readonly UserAuthService _UserAuthService;

        public ArticleController(ArticleService articleService,
            CategoryService categoryService,
            UserAuthService userAuthService)
        {
            this._ArticleService = articleService;
            this._CategoryService = categoryService;
            this._UserAuthService = userAuthService;
        }

        public ActionResult Index()
        {
            if (!Authorize(PermissionRecordProvider.ManageArticle))
                return AccessDeniedView();

            ArticleModel articleModel = new ArticleModel();
            articleModel.CategorySelectItems = getCateGorys();
            return View(articleModel);
        }

        [JsonCallback]
        public ActionResult List()
        {
            if (!Authorize(PermissionRecordProvider.ManageArticle))
                return AccessDeniedView();

            var articles = _ArticleService.GetArticles();
            IEnumerable<ArticleModel> articleModels = articles.Select(x => x.ToModel());
            return Json(articleModels);
        }

        [HttpPost]
        [JsonCallback]
        public ActionResult Create()
        {
            if (!Authorize(PermissionRecordProvider.ManageArticle))
                return AuthorizeGrid();

            var models = JsonConvert.DeserializeObject<IEnumerable<ArticleModel>>(Request.Params["models"]);

            if (models != null)
            {
                foreach (ArticleModel model in models)
                {
                    model.Id = Guid.NewGuid().ToString();
                    model.CreateAt = DateTime.Now;
                    string userID = _UserAuthService.CurrentUser.Id;
                    model.UserID = userID;
                }
                IEnumerable<Article> entitys = models.Select(e => e.ToEntity());
                _ArticleService.AddEntrys(entitys.ToList<Article>());
            }
            return Json(models);
        }

        public string ContentGet(string Id)
        {
            if (!Authorize(PermissionRecordProvider.ManageArticle))
                return AccessDenied;

            Article article = _ArticleService.GetArticleById(Id);
            return article.Content;
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult ContentUpdate(string Id,string MarkDown)
        {
            if (!Authorize(PermissionRecordProvider.ManageArticle))
                return AuthorizeJson();

            Article article = _ArticleService.GetArticleById(Id);
            article.Content = MarkDown;
            _ArticleService.Update(article);
            return Json(new { success = true, responseText = "保存成功" }, JsonRequestBehavior.AllowGet);
        }

        [JsonCallback]
        public ActionResult Update()
        {
            if (!Authorize(PermissionRecordProvider.ManageArticle))
                return AuthorizeJson();

            var models = JsonConvert.DeserializeObject<IEnumerable<ArticleModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<Article> entity = models.Select(e => e.ToEntity());
                _ArticleService.UpdateEntrys(entity.ToList<Article>());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Delete()
        {
            if (!Authorize(PermissionRecordProvider.ManageArticle))
                return AuthorizeJson();

            var callback = Request.Params["callback"];
            var models = JsonConvert.DeserializeObject<IEnumerable<ArticleModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<Article> entitys = models.Select(e => e.ToEntity());
                _ArticleService.DeleteEntrys(entitys.ToList<Article>());
            }
            return Json(models);
        }

        public ActionResult Content(string Id)
        {
            if (!Authorize(PermissionRecordProvider.ManageArticle))
                return AccessDeniedView();

            EditorModel editorModel = new EditorModel { Get = Url.Action("ContentGet", "Article"), Post = Url.Action("ContentUpdate", "Article"), ParameterId = Id };
            return View(editorModel);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(ArticleModel articleModel)
        {
            if (!Authorize(PermissionRecordProvider.ManageArticle))
                return AccessDeniedView();

            if (ModelState.IsValid)
            {
                Article article = articleModel.ToEntity();
                _ArticleService.Update(article);
                return RedirectToAction("Index");
            }
            articleModel.CategorySelectItems = getCateGorys();
            return View(articleModel);
        }

        private List<SelectListItem> getCateGorys()
        {
            IEnumerable<Category> categorys = _CategoryService.GetCategorys();
            var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="",Text="请选择",Selected=true}
            };
            var selectList = new SelectList(categorys, "Id", "Name");
            selectItemList.AddRange(selectList);
            return selectItemList;
        }

    }
}