using System.Web;
using System.Web.Optimization;

namespace NiscoutFBL2019
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                              "~/Content/assets/plugins/jquery/jquery.min.js",
                              "~/Content/assets/plugins/bootstrap/js/popper.min.js",
                              "~/Content/assets/plugins/bootstrap/js/bootstrap.min.js",
                              "~/Scripts/js/perfect-scrollbar.jquery.min.js",
                              "~/Scripts/js/waves.js",
                              "~/Scripts/js/sidebarmenu.js",
                              "~/Scripts/js/custom.min.js",
                              "~/Content/assets/plugins/chartist-js/dist/chartist.min.js",
                              "~/Content/assets/plugins/chartist-plugin-tooltip-master/dist/chartist-plugin-tooltip.min.js",
                              "~/Content/assets/plugins/d3/d3.min.js",
                              "~/Content/assets/plugins/c3-master/c3.min.js",
                              "~/Scripts/js/dashboard.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                             "~/Content/assets/plugins/bootstrap/css/bootstrap.min.css",
                             "~/Content/assets/plugins/chartist-js/dist/chartist.min.css",
                             "~/Content/assets/plugins/chartist-plugin-tooltip-master/dist/chartist-plugin-tooltip.css",
                             "~/Content/assets/plugins/c3-master/c3.min.css",
                             "~/Content/css/style.css",
                             "~/Content/css/ButtonStyles.css",
                             "~/Content/css/pages/dashboard.css",
                             "~/Content/css/colors/default-dark.css"
                            
                             ));
        }
    }
}
