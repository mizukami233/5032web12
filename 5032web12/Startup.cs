using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_5032web12.Startup))]
namespace _5032web12
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
