using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MSTest.PersonDetailsApp.Startup))]
namespace MSTest.PersonDetailsApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
