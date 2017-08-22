using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace yanzhilong.Areas.Admin.Controllers
{
    public class SecurityController : Controller
    {
        //权限拒绝
        public virtual ActionResult AccessDenied()
        {
            return View();
        }
    }
}