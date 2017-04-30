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
        public string Name { get; set; }
    }
}