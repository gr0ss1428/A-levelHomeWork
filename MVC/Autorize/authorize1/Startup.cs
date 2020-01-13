using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(authorize1.Startup))]
namespace authorize1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
