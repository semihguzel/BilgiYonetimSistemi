using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCOrnek12.Identity.Startup))]
namespace MVCOrnek12.Identity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
