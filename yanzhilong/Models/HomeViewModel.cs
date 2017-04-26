using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Domain;

namespace yanzhilong.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Article> articles { get; set; }
        public IEnumerable<Tutorials> tutorials { get; set; }
        public IEnumerable<Product> products { get; set; }
    }
}