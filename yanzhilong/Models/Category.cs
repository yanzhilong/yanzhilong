using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace yanzhilong.Models
{
    /// <summary>
    /// 文章分类表
    /// </summary>
    public class Category
    {
        public string CategoryID { get; set; }
        [DisplayName("分类")] //显示在Label上的名字
        public string Name { get; set; }
    }
}