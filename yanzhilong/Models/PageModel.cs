using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Models
{
    public class PageModel
    {
        public PageModel(int PageSize, int CurrentPage, int Count)
        {
           
            this.CurrentPage = CurrentPage;
            
            int PageCount = Count / PageSize;
            if (Count % PageSize == 0 && PageCount > 0)
            {
                PageCount--;
            }
            this.PageCount = PageCount;
        }

        public int PageCount { get; set; } //总页数
        public int CurrentPage { get; set; } //当前页
        public string actionName { get; set; } 
        public string controllerName { get; set; }
    }
}