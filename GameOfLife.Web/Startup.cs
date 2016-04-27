using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameOfLife.Web.Startup))]
namespace GameOfLife.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
