using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(webMiddle.Startup))]
namespace webMiddle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
