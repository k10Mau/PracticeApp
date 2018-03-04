using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyTestWebApi.Startup))]
namespace MyTestWebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
