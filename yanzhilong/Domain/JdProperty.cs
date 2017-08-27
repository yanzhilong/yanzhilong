using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yanzhilong.Domain
{
    public class JdProperty
    {
        public string Id { get; set; }//编号
        public string PropertyName { get; set; }//属性名称
        public string PropertyKey { get; set; }//属性值
        public bool isInput { get; set; }//是否是输入值，否就是选择值
    }
}