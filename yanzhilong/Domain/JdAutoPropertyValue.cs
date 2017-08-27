using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace yanzhilong.Domain
{
    public class JdAutoPropertyValue
    {
        public string Id { get; set; }
        public string JdAutoId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyKey { get; set; }
        public string ValueName { get; set; }
        public string ValueValue { get; set; }
        public int IsCheck { get; set; }
        public List<SelectListItem> CheckItems { get; set; }
    }
}