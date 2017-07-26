using AutoMapper;
using Newtonsoft.Json;
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
using yanzhilong.Infrastructure.Mapper;
using yanzhilong.Models;
using yanzhilong.Service;

namespace yanzhilong.Areas.Admin.Controllers
{
    public class FileController : Controller
    {
        private UploadFileService fileService = new UploadFileService();
        private FilePersistenceService filePersistenceService = new FilePersistenceService();


        [Authentication]
        [HttpPost]
        public JsonResult Upload(HttpPostedFileBase file)
        {
            JsonResult js = new JsonResult();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            UploadFile UploadFile = filePersistenceService.WriteFile(file, FileEnum.IMG);
            
            return Json(new { result = UploadFile != null ? UploadFile.Url : "" });
        }

        [Authentication]
        [HttpPost]
        public JsonResult UploadEditor()
        {
            HttpPostedFileBase EditFile = Request.Files["editormd-image-file"];
            UploadFile UploadFile = filePersistenceService.WriteFile(EditFile, FileEnum.IMG);
            if (UploadFile != null)
            {
                return Json(new {success = 1,url = UploadFile.Url});
            }
            return Json(new { success = 0, message = "上传失败" });
        }

        public ActionResult Details(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return HttpNotFound();
            }
            UploadFile uf = fileService.GetEntry(new UploadFile { Id = Id, Type = -1 });
            return View(uf.ToModel());
        }
        
        public FileResult Download(string Id)
        {
            UploadFile uf = fileService.GetEntry(new UploadFile { Id = Id, Type = -1 });
            return File(filePersistenceService.MakeFilePath(uf), "multipart/form-data", uf.SaveName);
        }

        [Authentication]
        public ActionResult Index()
        {
            UploadFile uploadFile = new UploadFile();
            return View(uploadFile.ToModel());
        }

        [Authentication]
        [JsonCallback]
        public ActionResult List()
        {
            var uploadFiles = fileService.GetEntrys(new UploadFile { Type = -1 }).ToList();
            List<UploadFileModel> uploadFileModels = uploadFiles.Select(x => x.ToModel()).ToList();
            return Json(uploadFileModels);
        }

        [Authentication]
        [JsonCallback]
        public ActionResult Update()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<UploadFileModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<UploadFile> entity = models.Select(e => e.ToEntity());
                fileService.UpdateEntrys(entity.ToList<UploadFile>());
            }
            return Json(models);
        }

        [Authentication]
        [JsonCallback]
        public ActionResult Delete()
        {
            var models = JsonConvert.DeserializeObject<IEnumerable<UploadFileModel>>(Request.Params["models"]);
            if (models != null)
            {
                IEnumerable<UploadFile> entitys = models.Select(e => e.ToEntity());
                foreach(UploadFile uf in entitys)
                {
                    filePersistenceService.DeleteFile(uf);
                }
                fileService.DeleteEntrys(entitys.ToList<UploadFile>());
            }
            return Json(models);
        }
    }
}