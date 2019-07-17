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
            CreateRolesandUsers();
        }

        // In this method we will create default User roles and Admin user for login
        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // In Startup iam creating first Admin Role and creating a default Admin User
            if (!roleManager.RoleExists("ADMIN"))
            {
                var role = new ApplicationRole
                {
                    Name = "ADMIN"
                };
                roleManager.Create(role);

                var user = new ApplicationUser
                {
                    UserName = "administrator@gmail.com",
                    Email = "administrator@gmail.com"
                };

                var chkUser = UserManager.Create(user, "123456");
                if (chkUser.Succeeded) UserManager.AddToRole(user.Id, "ADMIN");
            }

            if (!roleManager.RoleExists("PAGE_1"))
            {
                var role = new ApplicationRole();
                role.Name = "PAGE_1";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("PAGE_2"))
            {
                var role = new ApplicationRole();
                role.Name = "PAGE_2";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("PAGE_3"))
            {
                var role = new ApplicationRole();
                role.Name = "PAGE_3";
                roleManager.Create(role);
            }
        }
    }
}