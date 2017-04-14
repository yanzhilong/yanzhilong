using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Models;

namespace yanzhilong.Models
{
    public class ProductViewModel
    {
        public IList<Product> products { get; set; }
        public PagingViewModel pvm { get; set; }
    }
}