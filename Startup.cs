using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WhoLetDerHundOut.Startup))]
namespace WhoLetDerHundOut
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
