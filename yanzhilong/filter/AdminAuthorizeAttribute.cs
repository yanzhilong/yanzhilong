using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yanzhilong.Service;

namespace yanzhilong.filter
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class AdminAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var userAuthService = Autofac.Scope.Resolve<UserAuthService>();
            if(userAuthService.CurrentUser == null)
            {
                //登陆页面忽略
                string  controllerName = filterContext.Controller.ValueProvider.GetValue("controller").AttemptedValue;
                string actionName = filterContext.Controller.ValueProvider.GetValue("action").AttemptedValue;

                if (!String.IsNullOrEmpty(controllerName) && !String.IsNullOrEmpty(actionName)
                    && controllerName.Equals("Home", StringComparison.InvariantCultureIgnoreCase)
                    && actionName.Equals("Login", StringComparison.InvariantCultureIgnoreCase))
                    return;

                //注册页面忽略
                if (!String.IsNullOrEmpty(controllerName) && !String.IsNullOrEmpty(actionName)
                    && controllerName.Equals("Home", StringComparison.InvariantCultureIgnoreCase)
                    && actionName.Equals("Register", StringComparison.InvariantCultureIgnoreCase))
                    return;

                filterContext.Result = new EmptyResult();
                //跳转到登陆页
                filterContext.HttpContext.Response.Redirect("/Admin/Home/Login");
            }
        }
    }
}