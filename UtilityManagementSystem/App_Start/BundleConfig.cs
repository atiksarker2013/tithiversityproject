using System.Web;
using System.Web.Optimization;

namespace UtilityManagementSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.1.1.js",
                        "~/Scripts/modernizr-2.8.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryPrinting").Include(

                          "~/Content/assets/js/jquery-3.1.1.js",

                        "~/Scripts/jquery-ui-1.12.1.js",
                        "~/Printingcss/js/bootstrap.js",
                        "~/Printingcss/js/AdminLTE/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

 

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(

                "~/Scripts/moment.js",
                           "~/Scripts/bootstrap.js",
                           "~/Scripts/respond.js",
                            "~/Scripts/jquery-ui-1.12.1.js",
                           "~/Content/assets/js/jquery.metisMenu.js",
                           "~/Content/assets/js/custom.js",
                            "~/Scripts/jquery.dataTables.js",
                             "~/Scripts/dataTables.bootstrap.js",
                              "~/ckeditor/ckeditor.js"

                           ));

           
            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/themes/base/jquery-ui.css",
                     "~/Content/assets/css/bootstrap.css",
                     "~/Content/assets/css/font-awesome.css",
                     "~/Content/assets/css/style.css",
                     "~/Content/datatables/dataTables.bootstrap.css"));


            bundles.Add(new StyleBundle("~/Printingcss/css").Include(
                      "~/Printingcss/css/AdminLTE.css",
                      "~/Printingcss/css/bootstrap.css",
                      "~/Printingcss/css/ionicons.css"));
        }
    }
}
