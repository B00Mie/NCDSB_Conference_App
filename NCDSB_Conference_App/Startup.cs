using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NCDSB_Conference_App.Startup))]
namespace NCDSB_Conference_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
