using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Helper
{
    public class PageHelper
    {
        public const int PAGESIZE = 4;//默认分页大小
        public static Page makePage(int CurrentPage)
        {
            Page page = new Page();
            page.PageSize = PAGESIZE;
            page.PageSkip = CurrentPage * PAGESIZE;
            return page;
        }
    }

    public class Page
    {
        public int PageSize { get; set; }
        public int PageSkip { get; set; }
    }
}