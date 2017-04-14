using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Models
{
    public class PagingViewModel
    {
        public int PageCount { get; set; } //总页数
        public int CurrentPage { get; set; } //当前页
        public string actionName { get; set; } 
        public string controllerName { get; set; }
    }
}