using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AjaxApp.Startup))]
namespace AjaxApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
