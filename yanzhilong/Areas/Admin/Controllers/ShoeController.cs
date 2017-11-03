using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using yanzhilong.filter;
using yanzhilong.Domain;
using yanzhilong.Models;
using yanzhilong.Service;
using yanzhilong.Infrastructure.Mapper;
using Newtonsoft.Json;
using yanzhilong.Domain.Kendo;
using yanzhilong.Security;

namespace yanzhilong.Areas.Admin.Controllers
{
    public class ShoeController : BaseAdminController
    {
        private SxShoeServiceMB shoeCRUD = new SxShoeServiceMB();

        public ActionResult Index()
        {
            if (!Authorize(PermissionRecordProvider.ManageShoe))
                return AccessDeniedView();

            SxShoeModel SxShoeModel = new SxShoeModel();
            return View(SxShoeModel);
        }

        [JsonCallback]
        public ActionResult List()
        {
            if (!Authorize(PermissionRecordProvider.ManageShoe))
                return AuthorizeGrid();

            var models = JsonConvert.DeserializeObject<IEnumerable<SxShoeModel>>(Request.Params["models"]);
            SxShoeModel sxShoeModel = models.ToList()[0];
            
            var categorys = shoeCRUD.GetEntrys(new SxShoe { Price = -1, Popularity = -1, Sort = -1 });
                
            //IEnumerable<SxShoeModel> categoryModels = categorys.Select(x => x.ToModel());

            if (sxShoeModel != null && !string.IsNullOrEmpty(sxShoeModel.FilterTitle))
            {
                categorys = categorys.Where(s => s.Title.Contains(sxShoeModel.FilterTitle));
            }

            if (sxShoeModel != null && !string.IsNullOrEmpty(sxShoeModel.FilterNumber))
            {
                categorys = categorys.Where(s => s.Number.Equals(sxShoeModel.FilterNumber));
            }

            IEnumerable<SxShoeModel> categoryModels = categorys.Select(x => {

                var model = x.ToModel();
                return model;
            });

            return Json(categoryModels);
        }

        [JsonCallback]
        public ActionResult Update()
        {
            if (!Authorize(PermissionRecordProvider.ManageShoe))
                return AuthorizeGrid();

            var models = JsonConvert.DeserializeObject<IEnumerable<SxShoeModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<SxShoe> categorys = models.Select(e => e.ToEntity());
                shoeCRUD.UpdateEntrys(categorys.ToList<SxShoe>());
            }
            return Json(models);
        }        

        [JsonCallback]
        public ActionResult Create()
        {
            if (!Authorize(PermissionRecordProvider.ManageShoe))
                return AuthorizeGrid();

            var models = JsonConvert.DeserializeObject<IEnumerable<SxShoeModel>>(Request.Params["models"]);

            if (models != null)
            {
                foreach (SxShoeModel category in models)
                {
                    category.Id = Guid.NewGuid().ToString();
                }
                IEnumerable<SxShoe> categorys = models.Select(e => e.ToEntity());
                shoeCRUD.AddEntrys(categorys.ToList<SxShoe>());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Delete()
        {
            if (!Authorize(PermissionRecordProvider.ManageShoe))
                return AuthorizeGrid();

            var callback = Request.Params["callback"];
            var models = JsonConvert.DeserializeObject<IEnumerable<SxShoeModel>>(Request.Params["models"]);
            if (models != null)
            {
                List<SxShoe> categorys = models.Select(e => e.ToEntity()).ToList(); ;
                shoeCRUD.DeleteEntrys(categorys);
            }
            return Json(models);
            //return new JsonpResult<object>(models, callback);
        }
    }
}