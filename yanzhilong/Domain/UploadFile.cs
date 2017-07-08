using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace yanzhilong.Domain
{
    /// <summary>
    /// 文章表
    /// </summary>
    public class UploadFile
    {
        public string Id { get; set; } //编号
        public string SaveName { get; set; } //保存名称
        public string UploadName { get; set; } //上传时候的名称
        public string Url { get; set; } //路径
        public int Type { get; set; } //类型

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