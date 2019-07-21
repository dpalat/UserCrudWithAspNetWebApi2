using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using UserCrud.WebUI.Models;

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