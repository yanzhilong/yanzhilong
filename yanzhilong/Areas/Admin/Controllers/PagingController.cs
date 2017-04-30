using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yanzhilong.Domain;
using yanzhilong.Models;

namespace yanzhilong.Areas.Admin.Controllers
{
    public class PagingController : Controller
    {
        public ActionResult Index(PageModel pvm)
        {
            return PartialView("Paging", pvm);
        }
    }
}