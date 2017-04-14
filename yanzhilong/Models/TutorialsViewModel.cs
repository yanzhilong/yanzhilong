using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Models;

namespace yanzhilong.Models
{
    public class TutorialsViewModel
    {
        public IList<Tutorials> tutorials { get; set; }
        public PagingViewModel pvm { get; set; }
    }
}