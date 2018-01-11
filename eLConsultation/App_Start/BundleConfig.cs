using System.Web;
using System.Web.Optimization;

namespace eLConsultation
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*",
                "~/Scripts/jquery.validate.unobtrusive*"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Scripts/jquery/jquery.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                      //"~/Scripts/kendo/2017.2.621/jquery.min.js",
                      "~/Scripts/kendo/2017.2.621/jszip.min.js",
                      "~/Scripts/kendo/2017.2.621/kendo.all.min.js",
                      "~/Scripts/kendo/2017.2.621/kendo.aspnetmvc.min.js",
                      "~/Scripts/kendo.modernizr.custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                      "~/Scripts/popper.js",
                      "~/Scripts/pace.js",
                      "~/Scripts/Chart.js",
                      "~/Scripts/app.js",
                      "~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                      "~/Scripts/site.js"));

            bundles.Add(new ScriptBundle("~/bundles/accordion").Include(
                      "~/Scripts/accordion.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap/bootstrap").Include(
                    "~/Content/bootstrap/bootstrap-reboot.css",
                    "~/Content/bootstrap/bootstrap-grid.css",
                    "~/Content/bootstrap/bootstrap.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/kendo/2017.2.621/kendo").Include(
                    "~/Content/kendo/2017.2.621/kendo.common.min.css",
                    "~/Content/kendo/2017.2.621/kendo.mobile.all.min.css"
                      //"~/Content/kendo/2017.2.621/kendo.flat.min.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/accordion").Include(
                    "~/Content/accordion.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/eLColsultation.css",
                "~/Content/font-awesome.css",
                "~/Content/simple-line-icons.css",
                "~/Content/style.css",
                "~/Content/site.css"
                ));
        }
    }
}
