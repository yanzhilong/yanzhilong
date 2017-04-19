using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Models;

namespace yanzhilong.Models
{
    public class ResourceStarViewModel
    {
        public IList<ResourceStar> resourceStars { get; set; }
        public PagingViewModel pvm { get; set; }
    }
}