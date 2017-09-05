using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IMSApplication.Startup))]
namespace IMSApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
