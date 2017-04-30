using System.Web;
using System.Web.Optimization;

namespace yanzhilong
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/Content/list.css",
                      "~/Content/doc.css"));
            
            //教程详情,生成侧边栏js
            bundles.Add(new ScriptBundle("~/bundles/tutorials_details").Include(
                      "~/Scripts/tutorials_details_new.js"));

            //用于限制缩略显示行
            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                     "~/Scripts/clamp.js",
                     "~/Scripts/main.js"));

            //用于限制显示行
            bundles.Add(new ScriptBundle("~/bundles/list").Include(
                     "~/Scripts/list.js"));

            //用于管理端ajax请求管理页面
            bundles.Add(new ScriptBundle("~/bundles/manage").Include(
                      "~/Scripts/manage.js"));
        }
    }
}
