using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Domain
{
    public class JdAuto
    {
        public string Id { get; set; }//编号
        public string Name { get; set; }//配置名称
        public string PId { get; set; }//父级编号
    }
}