using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Domain
{
    public class ViewTotal
    {
        public string Id { get; set; }
        public string ResourceID { get; set; } //资源ID
        public int Total { get; set; } //计数
    }
}