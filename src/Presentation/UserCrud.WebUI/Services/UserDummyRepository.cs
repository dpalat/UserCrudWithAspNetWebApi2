using System.Collections.Generic;
using UserCrud.WebUI.Models.Identity;

namespace UserCrud.WebUI.Services
{
    public static class UserDummyRepository
    {
        public static List<ApplicationUser> DummyUsersList { get; set; }

        static UserDummyRepository()
        {
            DummyUsersList = new List<ApplicationUser>();
        }

        public static bool Add(ApplicationUser user)
        {
            DummyUsersList.Add(user);
            return true;
        }
    }
}