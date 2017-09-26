using System.Web;
using System.Web.Optimization;

namespace IMSApplication
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                "~/Scripts/dataTables/jquery.dataTables.js",
                "~/Scripts/dataTables/dataTables.bootstrap.js",
                "~/Scripts/custom.js"
            ));
            bundles.Add(new StyleBundle("~/Content/datatable").Include(
                "~/Scripts/dataTables/dataTables.bootstrap.css"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/font-awesome.css",
                      "~/Content/css/style.css"));
            bundles.Add(new StyleBundle("~/Content/datepicker").Include(
                    "~/Content/bootstrap-datetimepicker.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
                    "~/Scripts/moment.js",
                    "~/Scripts/bootstrap-datetimepicker.js"
                ));
            bundles.Add(new StyleBundle("~/Content/select2").Include(
                    "~/Content/select2/select2.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
                    "~/Scripts/select2/select2.js"
                ));
        }
    }
}
