using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iXOnlineWeb.Startup))]
namespace iXOnlineWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
