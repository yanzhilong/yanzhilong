using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Domain;

namespace yanzhilong.Models
{
    public class ResourceStarViewModel
    {
        public IList<ResourceStar> resourceStars { get; set; }
        public PageModel pvm { get; set; }
    }
}