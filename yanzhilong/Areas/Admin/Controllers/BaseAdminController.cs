using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yanzhilong.Domain.Kendo;
using yanzhilong.filter;
using yanzhilong.Service;

namespace yanzhilong.Areas.Admin.Controllers
{
    

    [AdminAuthorize]
    public class BaseAdminController : Controller
    {
        private readonly PermissionService _PermissionService;

        protected string AccessDenied = "您无权操作";
        //权限拒绝
        protected virtual ActionResult AccessDeniedView()
        {
            return RedirectToAction("AccessDenied", "Security");
        }

        protected virtual ActionResult AuthorizeGrid()
        {
            return Json(new DataSourceResult { Errors = AccessDenied });
        }

        protected virtual JsonResult AuthorizeJson()
        {
            return Json(new { success = false, responseText = AccessDenied }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 验证权限
        /// </summary>
        /// <param name="SystemName"></param>
        /// <returns></returns>
        protected virtual bool Authorize(string SystemName)
        {
            var _PermissionService = Autofac.Scope.Resolve<PermissionService>();
            return _PermissionService.Authorize(SystemName);
        }

        

    }
}