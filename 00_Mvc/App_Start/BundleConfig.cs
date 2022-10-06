using System.Web;
using System.Web.Optimization;

namespace _00_Mvc
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios.  De esta manera estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            //CSS
            bundles.Add(new ScriptBundle("~/Content/css").Include(
                      "~/Content/css/animate.css"));
            bundles.Add(new ScriptBundle("~/Content/css").Include(
                      "~/Content/css/flex-slider.css"));
            bundles.Add(new ScriptBundle("~/Content/css").Include(
                      "~/Content/css/fontawesome.css"));
            bundles.Add(new ScriptBundle("~/Content/css").Include(
                      "~/Content/css/owl.css"));
            bundles.Add(new ScriptBundle("~/Content/css").Include(
                      "~/Content/css/templatemo-cyborg-gaming.css"));
            //JS
            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                      "~/Scripts/js/custom.js"));
            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                     "~/Scripts/js/isotope.js"));
            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                     "~/Scripts/js/isotope.min.js"));
            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                     "~/Scripts/js/popup.js"));
            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                     "~/Scripts/js/tabs.js"));
            //Bootstrap jss and css
            bundles.Add(new ScriptBundle("~/Content/vendor/bootstrap/css").Include(
                     "~/Content/vendor/bootstrap/css/bootstrap.min.css"));
            bundles.Add(new ScriptBundle("~/Content/vendor/bootstrap/js").Include(
                    "~/Content/vendor/bootstrap/js/bootstrap.min.js"));




            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
