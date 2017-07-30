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
using System.Web.Script.Serialization;
using yanzhilong.Domain.Kendo;

namespace yanzhilong.Areas.Admin.Controllers
{
    public class TbItemController : Controller
    {
        private TbItemService tbItemService = new TbItemService();
        private FilePersistenceService filePersistenceService = new FilePersistenceService();

        [Authentication]
        public ActionResult Index()
        {
            TbItemModel tim = new TbItemModel();
            return View(tim);
        }

        [HttpPost]
        [JsonCallback]
        public ActionResult List()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<TbItemModel>>(Request.Params["models"]);
            TbItemModel tbItemModel = models.ToList()[0];

            var entrys = tbItemService.GetEntrys(new TbItem() { datatype = 3,sxurl = tbItemModel.sxurl, tburl = tbItemModel.tburl });

            //if (tbItemModel != null && !string.IsNullOrEmpty(tbItemModel.sxurl))
            //{
            //    entrys = entrys.Where(s => !string.IsNullOrEmpty(s.sxurl) && s.sxurl.Equals(tbItemModel.sxurl));
            //}

            //if (tbItemModel != null && !string.IsNullOrEmpty(tbItemModel.tburl))
            //{
            //    entrys = entrys.Where(s => !string.IsNullOrEmpty(s.tburl) && s.tburl.Equals(tbItemModel.tburl));
            //}

            if (!string.IsNullOrEmpty(tbItemModel.tburl) && tbItemModel.tburl.Equals("null"))
            {
                entrys = tbItemService.GetEntrys(new TbItem() { datatype = 3, sxurl = tbItemModel.sxurl });

                entrys = entrys.Where(s => string.IsNullOrEmpty(s.tburl));
            }


            IEnumerable<TbItemModel> entrymodels = entrys.Select(x => x.ToModel());

            return Json(entrymodels);
            //var serializer = new JavaScriptSerializer();
            //serializer.MaxJsonLength = Int32.MaxValue;
            
            //var result = new ContentResult
            //{
            //    Content = serializer.Serialize(entrymodels),
            //    ContentType = "application/json"
            //};
            ////return result;

            //JsonResult js = new JsonResult();
            //JavaScriptSerializer jss = new JavaScriptSerializer();
            //jss.MaxJsonLength = Int32.MaxValue;
            //js.Data = jss.Serialize(entrymodels);
            //js.MaxJsonLength = Int32.MaxValue;
            //return js;
        }

        [ValidateInput(false)]
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

        [ValidateInput(false)]
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

        [ValidateInput(false)]
        [JsonCallback]
        public ActionResult Delete()
        {
            var callback = Request.Params["callback"];
            var models = JsonConvert.DeserializeObject<IEnumerable<TbItemModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<TbItem> entrys = models.Select(e => e.ToEntity());
                foreach (TbItem t in entrys)
                {
                    if(t.DataTypeEnum != TbDataTypeEnum.TBDATA)
                    {
                        return Json(new DataSourceResult{ Errors = "系统保留数据，不能删除"});
                    }
                }
                tbItemService.DeleteEntrys(entrys.ToList<TbItem>());
            }
            return Json(models);
        }

        [ValidateInput(false)]
        [JsonCallback]
        public ActionResult ExportCsv()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<TbItemModel>>(Request.Params["models"]);

            List<TbItem> tbItems = new List<TbItem>();
            TbItem tbItem_en_title = tbItemService.GetEntry(new TbItem() { DataTypeEnum = TbDataTypeEnum.ENGLISHTITLE });
            TbItem tbItem_cn_title = tbItemService.GetEntry(new TbItem() { DataTypeEnum = TbDataTypeEnum.CNTITLE });
            TbItem tbItem_default_value = tbItemService.GetEntry(new TbItem() { DataTypeEnum = TbDataTypeEnum.DEFAULTDATA });
            List<TbItem> tbItem_tbdatas = tbItemService.GetEntrys(new TbItem() { DataTypeEnum = TbDataTypeEnum.TBDATA }).ToList<TbItem>();

            List<TbItem> tbItem_tbs = models.Select(t => t.ToEntity()).ToList();

            tbItems.Add(tbItem_en_title);
            tbItems.Add(tbItem_cn_title);
            tbItems.AddRange(tbItem_tbs);
            UploadFile UploadFile = filePersistenceService.WriteFile(tbItems);

            if (UploadFile != null)
            {
                return Json(new { success = 1, url = UploadFile.Url });
            }
            return Json(new { success = 1, message = "导出成功" });
        }

        [JsonCallback]
        public ActionResult DeleteAll()
        {
            
            List<TbItem> tbItem_tbdatas = tbItemService.GetEntrys(new TbItem() { DataTypeEnum = TbDataTypeEnum.TBDATA }).ToList<TbItem>();
            tbItemService.DeleteEntrys(tbItem_tbdatas);
            
            return Json(new { success = 1, message = "删除成功" });
        }
    }
}