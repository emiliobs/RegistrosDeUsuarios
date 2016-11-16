using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace RegistrosDeUsuarios.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-1.10.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
               "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryvalunobtrusive").Include(
                "~/Scripts/jquery.validate.unobtrusive.js"));

            //bundles.Add(new ScriptBundle("~/bundles/contacto-modal-ynnova").Include(
            //    "~/Scripts/contacto-modal-ynnova.js"));

            bundles.Add(new ScriptBundle("~/Content/css").Include(
                "~/Content/Style.css"));
            //bundles.Add(new ScriptBundle("~/Content/css").Include(
            //   "~/Content/bootstrap.css"));
        }
    }
}