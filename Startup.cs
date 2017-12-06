using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rythmm.Startup))]
namespace Rythmm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
