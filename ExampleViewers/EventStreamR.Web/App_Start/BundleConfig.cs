using System.Web;
using System.Web.Optimization;

namespace EventStreamR.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/sitebase").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.signalR-*",
                        "~/Content/Bootstrap/js/bootstrap.js",
                        "~/Scripts/knockout-{version}.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/cssbase").Include(
                        "~/Content/Bootstrap/css/bootstrap.css",
                        "~/Content/site.css"
                        ));
        }
    }
}