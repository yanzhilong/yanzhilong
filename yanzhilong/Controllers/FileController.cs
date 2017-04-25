using AutoMapper;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using yanzhilong.filter;

namespace yanzhilong.Controllers
{
    public class FileController : Controller
    {
        [Authentication]
        [HttpPost]
        public JsonResult Upload(HttpPostedFileBase file)
        {
            JsonResult js = new JsonResult();
            JavaScriptSerializer jss = new JavaScriptSerializer();

            string name = file.FileName;//获取上传的文件名
            string ext = System.IO.Path.GetExtension(name);// 获取文件的扩展名，比如 .gif
            DateTime dt = DateTime.Now;
            string newname = dt.ToString("yyyyMMddHHmmssffff") + ext;//利用时间生成新文件名后再加扩展名生成完整名字

            //string path1 = "~/img/" + newname;//保存的路径，注意一定要有load目录，不然会错
            //string filepath1 = System.Web.HttpContext.Current.Server.MapPath(path1);

            string path2 = "/img/" + newname;
            var filepath2 = Path.Combine(Request.MapPath("~/img"), newname);
            ResultInfo resultInfo = new ResultInfo();
            try
            {
                file.SaveAs(filepath2);
            }
            catch (Exception e)
            {
                resultInfo.result = "";
            }

            resultInfo.result = path2;
            js.Data = jss.Serialize(resultInfo);
            return js;
        }

        public ActionResult Upload()
        {
            return View();
        }

        class ResultInfo
        {
            public string result;
        }

        public ActionResult Test()
        {

            return Content("asdf");
        }


        public ActionResult Summernote()
        {
            return View();
        }


    }
}