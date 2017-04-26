using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace yanzhilong.Domain
{
    /// <summary>
    /// 文章分类表
    /// </summary>
    public class Category
    {
        public string CategoryID { get; set; }
        [Required(ErrorMessage = "请输入名称")] //必填项
        [DisplayName("分类名称")] //显示在Label上的名字
        public string Name { get; set; }
    }
}