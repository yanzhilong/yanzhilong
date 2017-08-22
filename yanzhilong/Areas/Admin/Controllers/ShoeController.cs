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
        private SxMainImageServiceMB sxMainImageServiceMB = new SxMainImageServiceMB();
        private SxImageServiceMB sxImageServiceMB = new SxImageServiceMB();
        private SxSsizeServiceMB sxSsizeServiceMB = new SxSsizeServiceMB();
        private SxPropertyServiceMB sxPropertyServiceMB = new SxPropertyServiceMB();
        private SxColorServiceMB sxColorServiceMB = new SxColorServiceMB();
        private TbItemService tbItemService = new TbItemService();


        private MakeTbItemService makeTbItemService = new MakeTbItemService();


        public ActionResult Index()
        {
            if (!Authorize(PermissionRecordProvider.ManageShoe))
                return AccessDeniedView();

            SxShoeModel SxShoeModel = new SxShoeModel();
            SxShoeModel.CidItems = ShoeCidHelper.GetShoeCidItems();
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

            List<SxMainImage> mainImagesAll = sxMainImageServiceMB.GetEntrys(new SxMainImage { sxShoe = new SxShoe { }, Sort = -1 }).ToList<SxMainImage>();

            IEnumerable<SxShoeModel> categoryModels = categorys.Select(x => {

                var model = x.ToModel();
                List<SxMainImage> mainImages = mainImagesAll.Where(e => e.sxShoe.Id == model.Id).ToList<SxMainImage>();
                SxMainImage smi = mainImages.Count > 0 ? mainImages[0] : null;
                model.MainImage = smi != null ? smi.Url : "";
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
        public ActionResult MakeTbItem(string Id)
        {
            if (!Authorize(PermissionRecordProvider.ManageShoe))
                return AuthorizeJson();

            SxShoe sxShoe = shoeCRUD.GetEntry(new SxShoe { Id = Id, Popularity = -1, Price = -1, Sort = -1 });
            //判断是否已经生成了
            TbItem t = tbItemService.GetEntry(new TbItem { datatype = -1, sxurl = sxShoe.Url });

            if(t != null)
            {
                return Json(new { success = false, responseText = "已经生成过宝贝" }, JsonRequestBehavior.AllowGet);//设置返回值，并允许get请求
            }

            TbItem tbItem = makeTbItemService.makeTbItem(sxShoe);
            tbItem.Id = Guid.NewGuid().ToString();
            tbItemService.AddEntry(tbItem);
            return Json(new { success = true, responseText = "生成成功" }, JsonRequestBehavior.AllowGet);//设置返回值，并允许get请求
        }

        [HttpPost]
        public ActionResult MakeTbItems(List<SxShoeModel> sxShoeModels)
        {
            if (!Authorize(PermissionRecordProvider.ManageShoe))
                return AuthorizeJson();

            var models = JsonConvert.DeserializeObject<IEnumerable<SxShoeModel>>(Request.Params["sxShoeModels"]);
            foreach (SxShoeModel sxShoeModel in models)
            {
                SxShoe sxShoe = shoeCRUD.GetEntry(new SxShoe { Id = sxShoeModel.Id, Popularity = -1, Price = -1, Sort = -1 });
                TbItem tbItem = makeTbItemService.makeTbItem(sxShoe);
                tbItem.Id = Guid.NewGuid().ToString();
                tbItemService.AddEntry(tbItem);
            }
            return Json(new { success = true, responseText = "生成成功" }, JsonRequestBehavior.AllowGet);//设置返回值，并允许get请求
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
                //删除size
                List<SxSsize> SxSsizes = sxSsizeServiceMB.GetEntrys(new SxSsize { sxShoe = new SxShoe { Id = categorys[0].Id }, Num = -1 }).ToList();
                sxSsizeServiceMB.DeleteEntrys(SxSsizes);
                //删除image
                List<SxImage> SxImage = sxImageServiceMB.GetEntrys(new SxImage { sxShoe = new SxShoe { Id = categorys[0].Id }, Sort = -1 }).ToList();
                sxImageServiceMB.DeleteEntrys(SxImage);

                //删除property
                List<SxProperty> SxProperty = sxPropertyServiceMB.GetEntrys(new SxProperty { sxShoe = new SxShoe { Id = categorys[0].Id } }).ToList();
                sxPropertyServiceMB.DeleteEntrys(SxProperty);

                //删除mainimage
                List<SxMainImage> SxMainImage = sxMainImageServiceMB.GetEntrys(new SxMainImage { sxShoe = new SxShoe { Id = categorys[0].Id }, Sort = -1 }).ToList();
                sxMainImageServiceMB.DeleteEntrys(SxMainImage);

                //删除color
                List<SxColor> SxColor = sxColorServiceMB.GetEntrys(new SxColor { sxShoe = new SxShoe { Id = categorys[0].Id } }).ToList();
                sxColorServiceMB.DeleteEntrys(SxColor);

                shoeCRUD.DeleteEntrys(categorys);
            }
            return Json(models);
            //return new JsonpResult<object>(models, callback);
        }
    }
}