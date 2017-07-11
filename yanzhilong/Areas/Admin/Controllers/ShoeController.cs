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

namespace yanzhilong.Areas.Admin.Controllers
{
    public class ShoeController : Controller
    {
        private SxShoeServiceMB shoeCRUD = new SxShoeServiceMB();
        private MakeTbItemService makeTbItemService = new MakeTbItemService();
        private TbItemService tbItemService = new TbItemService();


        [Authentication]
        public ActionResult Index()
        {
           
            return View();
        }

        [JsonCallback]
        public ActionResult List()
        {
            var categorys = shoeCRUD.GetEntrys(new SxShoe {Price = -1, Popularity = -1, Sort = -1 });
            IEnumerable<SxShoeModel> categoryModels = categorys.Select(x => x.ToModel());

            return Json(categoryModels);
        }

        [JsonCallback]
        public ActionResult Update()
        {
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
            SxShoe sxShoe = shoeCRUD.GetEntry(new SxShoe { Id = Id,Popularity = -1,Price = -1,Sort = -1});
            TbItem tbItem = makeTbItemService.makeTbItem(sxShoe);
            tbItem.Id = Guid.NewGuid().ToString();
            tbItemService.AddEntry(tbItem);
            return Json(new { success = true, responseText = "生成成功" }, JsonRequestBehavior.AllowGet);//设置返回值，并允许get请求
        }

        [JsonCallback]
        public ActionResult Create()
        {
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
            var callback = Request.Params["callback"];
            var models = JsonConvert.DeserializeObject<IEnumerable<SxShoeModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<SxShoe> categorys = models.Select(e => e.ToEntity());
                shoeCRUD.DeleteEntrys(categorys.ToList<SxShoe>());
            }
            return Json(models);
            //return new JsonpResult<object>(models, callback);
        }
    }
}