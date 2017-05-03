using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Domain
{
    public class PageViewCount
    {
        public string PageViewCountID { get; set; }
        public string ResourceID { get; set; } //资源ID
        public int Count { get; set; } //计数
    }
}