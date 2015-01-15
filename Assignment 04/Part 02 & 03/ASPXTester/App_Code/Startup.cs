using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPXTester.Startup))]
namespace ASPXTester
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
