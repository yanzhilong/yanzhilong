using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yanzhilong.filter;

namespace yanzhilong.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class BaseAdminController : Controller
    {

    }
}