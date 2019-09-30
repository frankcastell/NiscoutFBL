using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NiscoutFBL2019.Startup))]
namespace NiscoutFBL2019
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
