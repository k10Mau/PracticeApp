using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MSTest.PersonDetailsApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
        protected void Application_Error()
        {
            var error = Server.GetLastError();
            //TODO: log exception in DB
        }

        protected void Application_EndRequest()
        {
            switch(Context.Response.StatusCode)
            {
                case 500:
                    Response.Clear();
                    Response.Redirect("~/Error");
                    break;
                case 404:
                    Response.Clear();
                    Response.Redirect("~/Error");
                    break;
            }
        }
    }
}
