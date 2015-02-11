using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InfinysBreakfastOrders.Web.Startup))]
namespace InfinysBreakfastOrders.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
