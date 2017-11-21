using System.Web;
using System.Web.Optimization;

namespace IMSApps_v1
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/templatecorestyle").Include(
                "~/Content/googlefont/latin.cyrillic-ext.css",
                "~/Content/googlefont/material-icons.css",
                "~/Content/plugins/bootstrap/css/bootstrap.css",
                "~/Content/plugins/node-waves/waves.css",
                "~/Content/plugins/animate-css/animate.css",
                "~/Content/css/style.css",
                "~/Content/css/themes/all-themes.css"
                ));
            bundles.Add(new ScriptBundle("~/Content/temlplatecorescript").Include(
                "~/Content/plugins/jquery/jquery.min.js",
                "~/Content/plugins/bootstrap/js/bootstrap.js",
                //"~/Content/plugins/bootstrap-select/js/bootstrap-select.js",
                "~/Content/plugins/jquery-slimscroll/jquery.slimscroll.js",
                "~/Content/plugins/node-waves/waves.js"
                ));
        }
    }
}
