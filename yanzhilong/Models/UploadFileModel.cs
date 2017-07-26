using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Domain;

namespace yanzhilong.Models
{
    public class UploadFileModel
    {
        public string Id { get; set; } //编号
        public string SaveName { get; set; } //保存名称
        public string UploadName { get; set; } //上传时候的名称
        public string Url { get; set; } //路径
        public int Type { get; set; } //类型

        public string TypeStr
        {
            get
            {
                switch (this.Type)
                {
                    case (int)FileEnum.IMG:
                        return "图片";
                    case (int)FileEnum.RESOURCE:
                        return "资源";
                    case (int)FileEnum.TEMP:
                        return "临时";
                }
                return "";
            }
        }
        /// <summary>
        /// 文件类型枚举
        /// </summary>
        public FileEnum FileType
        {
            get
            {
                return (FileEnum)this.Type;
            }
            set
            {
                this.Type = (int)value;
            }
        }
    }
}