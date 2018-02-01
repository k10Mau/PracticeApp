using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TraningManagementServices.Contract;
using TraningManagementServices.DataAccess;
using TraningManagementServices.Implementation;

namespace TraniningManagementAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Mapper.Initialize(c => c.CreateMap<TraningCourses, Course>());
            //  ViewEngines.Engines.Clear();
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            // Log application level exceptions
        }

        protected void Application_EndRequest()
        {
            ILogger log = new Logger();
            if (Context.Response.StatusCode != 200 && Context.Response.StatusCode != 302 && Context.Response.StatusCode != 400)
            {
                var statusCode = Response.StatusCode;
                switch (statusCode)
                {
                    case 400:
                        Response.Clear();
                        //Exception ex = new Exception();
                        //ex.Message = "Bad re";
                        //log.LogError("Bad request");
                        break;
                    case 404:
                        Response.Clear();
                        //Response.Redirect("~/Home/Error");
                        break;
                    case 500:
                        Response.Clear();
                        //Response.Redirect("~/Home/Error");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
