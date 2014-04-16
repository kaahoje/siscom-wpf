using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestauranteMobile.Startup))]
namespace RestauranteMobile
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
