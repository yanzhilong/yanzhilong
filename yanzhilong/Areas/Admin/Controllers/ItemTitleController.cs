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
using yanzhilong.Security;
using System.Collections;

namespace yanzhilong.Areas.Admin.Controllers
{
    public class ItemTitleController : BaseAdminController
    {
        private readonly ItemTitleServiceMB _ItemTitleServiceMB;

        public ItemTitleController(ItemTitleServiceMB itemTitleServiceMB)
        {
            _ItemTitleServiceMB = itemTitleServiceMB;
        }

        public ActionResult Index()
        {
            if (!Authorize(PermissionRecordProvider.ManageItemTitle))
                return AccessDeniedView();

            return View(new ItemTitleModel());
        }
        
        [JsonCallback]
        public ActionResult List()
        {
            if (!Authorize(PermissionRecordProvider.ManageItemTitle))
                return AuthorizeGrid();

            var entrys = _ItemTitleServiceMB.GetEntrys(new ItemTitle { });
            IEnumerable<ItemTitleModel> entrymodels = entrys.Select(x => x.ToModel());
            return Json(entrymodels);
        }

        [JsonCallback]
        public ActionResult Update()
        {
            if (!Authorize(PermissionRecordProvider.ManageItemTitle))
                return AuthorizeGrid();

            var models = JsonConvert.DeserializeObject<IEnumerable<ItemTitleModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<ItemTitle> entrys = models.Select(e => e.ToEntity());
                _ItemTitleServiceMB.UpdateEntrys(entrys.ToList <ItemTitle> ());
            }
            return Json(models);
        }

        [JsonCallback]
        public ActionResult Create()
        {
            if (!Authorize(PermissionRecordProvider.ManageItemTitle))
                return AuthorizeGrid();

            var models = JsonConvert.DeserializeObject<IEnumerable<ItemTitleModel>>(Request.Params["models"]);

            if (models != null)
            {
                foreach (ItemTitleModel entry in models)
                {
                    entry.Id = Guid.NewGuid().ToString();
                }
                IEnumerable<ItemTitle> entrys = models.Select(e => e.ToEntity());
                _ItemTitleServiceMB.AddEntrys(entrys.ToList<ItemTitle>());
            }
            return Json(models);
        }

        /// <summary>
        /// 生成标题
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult MakeTitle(string Id)
        {
            if (!Authorize(PermissionRecordProvider.ManageItemTitle))
                return AuthorizeGrid();

            ItemTitle it = _ItemTitleServiceMB.GetEntry(new ItemTitle { Id = Id });
            if (it != null)
            {
                string[] items = it.TitleItems.Split(',');

                List<string> itemlist = new List<string>();
                itemlist.AddRange(items);

                itemlist = RandomSortList(itemlist);

                string result = "";
                foreach (string s in itemlist)
                {
                    result = result + s;
                }
                return Json(new { success = true, responseText = result }, JsonRequestBehavior.AllowGet);//设置返回值，并允许get请求
            }
            return Json(new { success = false, responseText = "生成失败" }, JsonRequestBehavior.AllowGet);//设置返回值，并允许get请求
        }

        public List<string> RandomSortList(List<string> ListT)
        {
            Random random = new Random();
            List<string> newList = new List<string>();
            while(ListT.Count > 0)
            {
                int randomindex = random.Next(ListT.Count);
                string s = ListT[randomindex];
                newList.Add(s);
                ListT.RemoveAt(randomindex);
            }
            return newList;
        }


        [JsonCallback]
        public ActionResult Delete()
        {
            if (!Authorize(PermissionRecordProvider.ManageItemTitle))
                return AuthorizeGrid();

            var callback = Request.Params["callback"];
            var models = JsonConvert.DeserializeObject<IEnumerable<ItemTitleModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<ItemTitle> entrys = models.Select(e => e.ToEntity());
                _ItemTitleServiceMB.DeleteEntrys(entrys.ToList<ItemTitle>());
            }
            return Json(models);
        }
    }
}