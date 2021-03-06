using System.Web.Optimization;

namespace MVCPersonalSite
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Content/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Content/Scripts/bootstrap.js",
            //          "~/Content/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/template").Include( "~/Content/Scripts/bootstrap.js", "~/Content/Scripts/isotope.min.js", "~/Content/Scripts/validate.js", "~/Content/Scripts/prettyphoto.js", "~/Content/Scripts/hoverdir.js", "~/Content/Scripts/hoverex.min.js", "~/Content/Scripts/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css", "~/Content/font-awesome/css/font-awesome.min.css", "~/Content/prettyphoto.css", "~/Content/hoverex-all.css", "~/Content/css/style.css"));
        }
    }
}
