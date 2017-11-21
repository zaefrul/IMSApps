using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IMSApps_v1.Startup))]
namespace IMSApps_v1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
