using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Models;

namespace yanzhilong.Models
{
    public class ActicleViewModel
    {
        public IList<Article> articles { get; set; }
        public PagingViewModel pvm { get; set; }
    }
}