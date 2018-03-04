using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyTestWebApi
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewEngines.Engines.Clear(); 
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            //TODO Log application level exceptions
        }

        protected void Application_EndRequest()
        {
            if (Context.Response.StatusCode != 200 && Context.Response.StatusCode != 302 &&
                Context.Response.StatusCode != 400)
            {
                switch (Context.Response.StatusCode)
                {
                    case 404:
                        Response.Clear();
                        HttpContext.Current.Response.Redirect("~/Error/Index");
                        break;
                    case 500:
                        Response.Clear();
                        HttpContext.Current.Response.Redirect("~/Error/Index");
                        break;
                    
                }
            }
        }
    }
}
