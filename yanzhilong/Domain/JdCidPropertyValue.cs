using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Domain
{
    public class JdCidPropertyValue
    {
        public string Id { get; set; }//编号
        public JdCid JdCid { get; set; }//类目
        public JdProperty JdProperty { get; set; }//属性
        public JdValue JdValue { get; set; }//属性值
    }
}