using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MatricResultsFinal.Startup))]
namespace MatricResultsFinal
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
