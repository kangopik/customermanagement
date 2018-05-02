using System.Web;
using System.Web.Optimization;

namespace CustomerManagement
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/alertjs").Include(
                        "~/Content/alertify/lib/alertify.js",
                        "~/Scripts/sweetalert.js"));

            bundles.Add(new ScriptBundle("~/bundles/mainjs").Include(
                        "~/Scripts/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatablesjs").Include(
                        "~/Content/datatables/js/jquery.dataTables.js",
                        "~/Content/datatables/js/dataTables.bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/datepickerjs").Include(
                        "~/Scripts/bootstrap-datepicker.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            
            bundles.Add(new StyleBundle("~/Content/bootstrapcss").Include(
                        "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/font-awesomecss").Include(
                        "~/Content/font-awesome/css/font-awesome.css",
                        "~/Content/font-awesome/fonts/fontawesome-*",
                        "~/Content/font-awesome/fonts/FontAwesome.otf"));

            bundles.Add(new StyleBundle("~/Content/alertcss").Include(
                        "~/Content/alertify/themes/alertify.bootstrap.css",
                        "~/Content/alertify/themes/alertify.core.css",
                        "~/Content/sweetalert.css"));

            bundles.Add(new StyleBundle("~/Content/maincss").Include(
                        "~/Content/AdminLTE.min.css",
                        "~/Content/_all-skins.min.css"));

            bundles.Add(new StyleBundle("~/Content/datatablescss").Include(
                        "~/Content/datatables/css/dataTables.bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/datepickercss").Include(
                        "~/Content/bootstrap-datepicker.min.css"));

        }
    }
}
