using System.Web;
using System.Web.Mvc;
using yanzhilong.filter;

namespace yanzhilong
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
