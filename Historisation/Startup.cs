using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Historisation.Startup))]
namespace Historisation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
