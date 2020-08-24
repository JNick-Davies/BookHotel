using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookHotel.WebMVC.Startup))]
namespace BookHotel.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
