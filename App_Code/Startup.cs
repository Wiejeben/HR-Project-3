using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project3Web.Startup))]
namespace Project3Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
