using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Tuincentrum.Startup))]
namespace MVC_Tuincentrum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
