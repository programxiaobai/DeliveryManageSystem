using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeliveryManageSystem.Startup))]
namespace DeliveryManageSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
