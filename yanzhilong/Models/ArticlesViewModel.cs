using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Domain;

namespace yanzhilong.Models
{
    public class ArticlesViewModel
    {
        public IList<Article> articles { get; set; }
        public PagingViewModel pvm { get; set; }
    }
}