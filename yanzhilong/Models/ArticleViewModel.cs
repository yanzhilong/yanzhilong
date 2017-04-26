using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Domain;

namespace yanzhilong.Models
{
    public class ArticleViewModel
    {
        public Article Current { get; set; }
        public Article Pre { get; set; }
        public Article Next { get; set; }
    }
}