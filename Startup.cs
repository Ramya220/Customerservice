using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Customerservice.Startup))]
namespace Customerservice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}