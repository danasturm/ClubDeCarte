using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClubDeCarte.Startup))]
namespace ClubDeCarte
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
