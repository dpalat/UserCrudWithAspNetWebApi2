using System;
using System.Collections.Generic;
using System.Linq;
using UserCrud.Entity;
using UsersCrud.Repository;

namespace UserCrud.Domain.DefaultData
{
    public class SeedUser : ISeedUser
    {
        public void Seed(IRepository<User> userRepository)
        {
            var role1 = new List<string> { "PAGE_1" };
            var role2 = new List<string> { "PAGE_2" };
            var role3 = new List<string> { "PAGE_3" };
            var roleAdmin = new List<string> { "ADMIN" };

            userRepository.Save(BuildUser("admin", roleAdmin));

            userRepository.Save(BuildUser("1", role1));
            userRepository.Save(BuildUser("2", role2));
            userRepository.Save(BuildUser("2", role3));

            userRepository.Save(BuildUser("DarthVader", roleAdmin.Union(role1).Union(role2).ToList()));
            userRepository.Save(BuildUser("LeiaOrgana", role1.Union(role2).ToList()));
            userRepository.Save(BuildUser("LukeSkywalker", role3.Union(role1).ToList()));
            userRepository.Save(BuildUser("Chewbacca", role1.Union(role2).ToList()));
            userRepository.Save(BuildUser("Obi_Wan_Kenobi", role1.Union(role2).Union(role3).ToList()));
            userRepository.Save(BuildUser("Yoda", roleAdmin));
            userRepository.Save(BuildUser("C3PO", role3));
            userRepository.Save(BuildUser("BobaFett", role1.Union(role3).ToList()));
            userRepository.Save(BuildUser("HanSolo", role3));
            userRepository.Save(BuildUser("Palpatine", roleAdmin));
            userRepository.Save(BuildUser("R2D2", role2.Union(role3).ToList()));
        }

        private User BuildUser(string userName, List<string> roles)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Roles = roles,
                UserEmail = $"{userName}@user.com",
                UserName = $"{userName}@user.com"
            };
        }
    }
}