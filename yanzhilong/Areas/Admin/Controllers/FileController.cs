using AutoMapper;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using yanzhilong.Domain;
using yanzhilong.filter;
using yanzhilong.Service;

namespace yanzhilong.Areas.Admin.Controllers
{
    public class FileController : Controller
    {
        private UploadFileService fileService = new UploadFileService();
        [Authentication]
        [HttpPost]
        public JsonResult Upload(HttpPostedFileBase file)
        {
            JsonResult js = new JsonResult();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            ResultInfo resultInfo = new ResultInfo();
            UploadFile UploadFile = uploadFile(file);
            if(UploadFile != null)
            {
                resultInfo.result = UploadFile.Url;
            }
            js.Data = jss.Serialize(resultInfo);
            return js;
        }


        [Authentication]
        [HttpPost]
        public JsonResult UploadEditor()
        {
            HttpPostedFileBase EditFile = Request.Files["editormd-image-file"];
            UploadFile UploadFile = uploadFile(EditFile);
            if (UploadFile != null)
            {
                return Json(new {success = 1,url = UploadFile.Url});
            }
            return Json(new { success = 0, message = "上传失败" });
        }


        //上传文件
        public UploadFile uploadFile(HttpPostedFileBase file)
        {
            if(file == null)
            {
                return null;
            }
            UploadFile uploadFile = new UploadFile();
            string name = file.FileName;//获取上传的文件名
            string ext = System.IO.Path.GetExtension(name);// 获取文件的扩展名，比如 .gif
            DateTime dt = DateTime.Now;
            string newname = dt.ToString("yyyyMMddHHmmssffff") + ext;//利用时间生成新文件名后再加扩展名生成完整名字

            //string path1 = "~/img/" + newname;//保存的路径，注意一定要有load目录，不然会错
            //string filepath1 = System.Web.HttpContext.Current.Server.MapPath(path1);

            //判断文件类型,得到路径
            string path2 = "/file/img/" + newname;
            var filepath2 = Path.Combine(Request.MapPath("~/file/img"), newname);
            try
            {
                file.SaveAs(filepath2);
                uploadFile.Id = Guid.NewGuid().ToString();
                uploadFile.SaveName = newname;
                uploadFile.UploadName = name;
                uploadFile.Url = path2;
                uploadFile.Type = (int)FileEnum.IMG;
                fileService.Create(uploadFile);
                return uploadFile;
            }
            catch (Exception e)
            {
                return null;
            }
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