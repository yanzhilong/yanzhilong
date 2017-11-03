using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using yanzhilong.Domain;

namespace yanzhilong.Service
{
    /// <summary>
    /// 文件持久层服务类
    /// </summary>
    public class FilePersistenceService
    {
        private UploadFileService fileService = new UploadFileService();

        /// <summary>
        /// 写入上传的文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileEnum"></param>
        /// <returns></returns>
        public UploadFile WriteFile(HttpPostedFileBase file, FileEnum fileEnum)
        {
            if (file == null)
            {
                return null;
            }
            UploadFile uploadFile = new UploadFile();
            string UploadName = file.FileName;//获取上传的文件名
            string ext = System.IO.Path.GetExtension(UploadName);// 获取文件的扩展名，比如 .gif
            DateTime dt = DateTime.Now;
            string SaveName = dt.ToString("yyyyMMddHHmmssffff") + ext;//利用时间生成新文件名后再加扩展名生成完整名字

            //判断文件类型,得到路径
            string Url = MakeFilePath(fileEnum) + SaveName;
            var lastfilepath = Path.Combine(HttpContext.Current.Request.MapPath(MakeFilePath(fileEnum)), SaveName);
            try
            {
                file.SaveAs(lastfilepath);
                uploadFile.Id = Guid.NewGuid().ToString();
                uploadFile.SaveName = SaveName;
                uploadFile.UploadName = UploadName;
                uploadFile.Url = Url;
                uploadFile.Type = (int)fileEnum;
                fileService.AddEntry(uploadFile);
                return uploadFile;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="uploadFile"></param>
        public void DeleteFile(UploadFile uploadFile)
        {
            string filePath = HttpContext.Current.Request.MapPath(uploadFile.Url);
            FileInfo file = new FileInfo(filePath);//指定文件路径
            if (file.Exists)//判断文件是否存在
            {
                file.Attributes = FileAttributes.Normal;//将文件属性设置为普通,比方说只读文件设置为普通
                file.Delete();//删除文件
            }
        }

        /// <summary>
        /// 得到文件路径
        /// </summary>
        /// <param name="uploadFile"></param>
        public string MakeFilePath(UploadFile uploadFile)
        {
            string filePath = HttpContext.Current.Request.MapPath(uploadFile.Url);
            return filePath;
        }

        /// <summary>
        /// 得到保存的路径
        /// </summary>
        /// <param name="fileEnum"></param>
        /// <returns></returns>
        private string MakeFilePath(FileEnum fileEnum)
        {
            switch (fileEnum)
            {
                case FileEnum.IMG:
                    return "/file/img/";
                case FileEnum.RESOURCE:
                    return "/file/resource/";
                case FileEnum.TEMP:
                    return "/file/temp/";
            }
            return null;
        }
    }
}