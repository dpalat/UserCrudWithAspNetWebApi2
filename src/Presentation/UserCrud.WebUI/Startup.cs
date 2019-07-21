using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UserCrud.WebUI.Startup))]

namespace UserCrud.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}