using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace yanzhilong.filter
{
    // 登录认证特性
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (filterContext.HttpContext.Session["UserID"] == null)
            {
                //跳转到登陆页
                filterContext.HttpContext.Response.Redirect("/Home/");
            } 
        }
    }
}