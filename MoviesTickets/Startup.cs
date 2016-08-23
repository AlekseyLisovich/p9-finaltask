using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoviesTickets.Startup))]
namespace MoviesTickets
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
