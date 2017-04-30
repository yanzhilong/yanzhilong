using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace yanzhilong.Domain
{
    /// <summary>
    /// 资源推荐
    /// </summary>
    public class ResourceStar
    {
        public string ResourceStarID { get; set; }
        public string ResourceID { get; set; }
        public int ResourceType { get; set; }
    }
}