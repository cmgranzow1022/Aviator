using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Aviator.Startup))]
namespace Aviator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
