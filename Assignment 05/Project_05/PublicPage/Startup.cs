using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PublicPage.Startup))]
namespace PublicPage
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
