using System.Web;
using System.Web.Optimization;

namespace yanzhilong
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //    "~/Content/editor.md-master/examples/js/jquery.min.js",
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
               "~/Scripts/jquery.min.js"));

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
                      "~/Scripts/tutorials_details.js"));

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

            //editor.md css
            bundles.Add(new StyleBundle("~/bundles/editor/css").Include(
                    "~/Content/editor.md-master/css/editormd.css"));

            //editor.md css
            bundles.Add(new StyleBundle("~/bundles/editor/previewcss").Include(
                    "~/Content/editor.md-master/css/editormd.preview.css"));

            //editor.md js
            bundles.Add(new ScriptBundle("~/bundles/editor/js").Include(
            "~/Content/editor.md-master/editormd.min.js"));

            //editor.md js
            bundles.Add(new ScriptBundle("~/bundles/editor/previewjs").Include(
            "~/Content/editor.md-master/lib/marked.min.js",
            "~/Content/editor.md-master/lib/prettify.min.js",
            "~/Content/editor.md-master/lib/raphael.min.js",
            "~/Content/editor.md-master/lib/underscore.min.js",
            "~/Content/editor.md-master/lib/sequence-diagram.min.js",
            "~/Content/editor.md-master/lib/flowchart.min.js",
            "~/Content/editor.md-master/lib/jquery.flowchart.min.js",
            "~/Content/editor.md-master/editormd.js"));
            
             

        }
    }
}
