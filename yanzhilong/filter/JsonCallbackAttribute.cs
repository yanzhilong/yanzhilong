using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace yanzhilong.filter
{
    /// <summary>
    /// 为jsonp自动加上callback
    /// </summary>
    public class JsonCallbackAttribute : ActionFilterAttribute
    {
        private const string CallbackQueryParameter = "callback";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// 为callback加上头
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var callback = string.Empty;

            if (IsJsonp(out callback))
            {
                var jsonBuilder = new StringBuilder(callback);

                JsonResult jr = null;
                try
                {
                    jr = (JsonResult)filterContext.Result;
                    var jsonstring = new JavaScriptSerializer().Serialize(jr.Data);

                    jsonBuilder.AppendFormat("({0})", jsonstring);
                    ContentResult cr = new ContentResult();
                    cr.Content = jsonBuilder.ToString();
                    filterContext.Result = cr;

                }
                catch(Exception e)
                {
                    
                }
            }

            base.OnActionExecuted(filterContext);
        }

        private bool IsJsonp(out string callback)
        {
            callback = HttpContext.Current.Request.QueryString[CallbackQueryParameter];

            return !string.IsNullOrEmpty(callback);
        }
    }
}