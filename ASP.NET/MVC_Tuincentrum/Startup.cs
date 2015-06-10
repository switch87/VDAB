using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Tuincentrum1.Startup))]
namespace MVC_Tuincentrum1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
