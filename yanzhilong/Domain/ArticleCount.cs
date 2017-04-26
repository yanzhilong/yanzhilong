using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Domain;

namespace yanzhilong.Domain
{
    public class ArticleCount
    {
        public Category category { get; set; }
        public int Count { get; set; }
    }
}