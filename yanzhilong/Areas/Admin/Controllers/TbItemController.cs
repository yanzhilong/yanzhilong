using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using yanzhilong.filter;
using yanzhilong.Domain;
using yanzhilong.Models;
using yanzhilong.Service;
using yanzhilong.Infrastructure.Mapper;
using yanzhilong.Helper;
using Newtonsoft.Json;

namespace yanzhilong.Areas.Admin.Controllers
{
    public class TbItemController : Controller
    {
        private TbItemService tbItemService = new TbItemService();
        private FilePersistenceService filePersistenceService = new FilePersistenceService();

        [Authentication]
        public ActionResult Index()
        {
            return View();
        }

        [JsonCallback]
        public ActionResult List()
        {
            var entrys = tbItemService.GetEntrys(new TbItem() { datatype = -1 });
            IEnumerable<TbItemModel> entrymodels = entrys.Select(x => x.ToModel());
            return Json(entrymodels);
        }
        
        [JsonCallback]
        public ActionResult Update()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<TbItemModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<TbItem> entrys = models.Select(e => e.ToEntity());
                tbItemService.UpdateEntrys(entrys.ToList <TbItem> ());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Create()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<TbItemModel>>(Request.Params["models"]);

            if (models != null)
            {
                foreach (TbItemModel entry in models)
                {
                    entry.Id = Guid.NewGuid().ToString();
                }
                IEnumerable<TbItem> entrys = models.Select(e => e.ToEntity());
                tbItemService.AddEntrys(entrys.ToList<TbItem>());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Delete()
        {
            var callback = Request.Params["callback"];
            var models = JsonConvert.DeserializeObject<IEnumerable<TbItemModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<TbItem> entrys = models.Select(e => e.ToEntity());
                tbItemService.DeleteEntrys(entrys.ToList<TbItem>());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult ExportCsv()
        {
            List<TbItem> tbItems = new List<TbItem>();
            TbItem tbItem_en_title = tbItemService.GetEntry(new TbItem() { DataTypeEnum = TbDataTypeEnum.ENGLISHTITLE });
            TbItem tbItem_cn_title = tbItemService.GetEntry(new TbItem() { DataTypeEnum = TbDataTypeEnum.CNTITLE });
            TbItem tbItem_default_value = tbItemService.GetEntry(new TbItem() { DataTypeEnum = TbDataTypeEnum.DEFAULTDATA });
            tbItem_default_value.title = "呵呵可可园欧文i";
            List<TbItem> tbItem_tbdatas = tbItemService.GetEntrys(new TbItem() { DataTypeEnum = TbDataTypeEnum.TBDATA }).ToList<TbItem>();
            tbItems.Add(tbItem_en_title);
            tbItems.Add(tbItem_cn_title);
            tbItems.Add(tbItem_default_value);
            tbItems.AddRange(tbItem_tbdatas);
            UploadFile UploadFile = filePersistenceService.WriteFile(tbItems);

            if (UploadFile != null)
            {
                return Json(new { success = 1, url = UploadFile.Url });
            }
            return Json(new { success = 0, message = "上传失败" });
        }
    }
}