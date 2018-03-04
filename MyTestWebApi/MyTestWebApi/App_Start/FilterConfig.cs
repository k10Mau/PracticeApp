using System.Web.Mvc;

namespace MyTestWebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
           // filters.Add(new ExceptionFilter()); Implement IException
        }
    }
}
