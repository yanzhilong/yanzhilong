using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using yanzhilong.Service;

namespace yanzhilong.filter
{
    // 登录认证特性
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userAuthService = Autofac.Scope.Resolve<UserAuthService>();
            if (userAuthService.CurrentUser == null)
            {
                filterContext.Result = new EmptyResult();
                //跳转到登陆页
                filterContext.HttpContext.Response.Redirect("/Admin/Home/Login");
            }
        }
    }
}