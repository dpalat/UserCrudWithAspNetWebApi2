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

            userRepository.Save(BuildUser("Darth Vader", roleAdmin.Union(role1).Union(role2).ToList()));
            userRepository.Save(BuildUser("Leia Organa", role1.Union(role2).ToList()));
            userRepository.Save(BuildUser("Luke Skywalker", role3.Union(role1).ToList()));
            userRepository.Save(BuildUser("Chewbacca", role1.Union(role2).ToList()));
            userRepository.Save(BuildUser("Obi Wan Kenobi", role1.Union(role2).Union(role3).ToList()));
            userRepository.Save(BuildUser("Yoda", roleAdmin));
            userRepository.Save(BuildUser("C3PO", role3));
            userRepository.Save(BuildUser("Boba Fett", role1.Union(role3).ToList()));
            userRepository.Save(BuildUser("Han Solo", role3));
            userRepository.Save(BuildUser("Palpatine", roleAdmin));
            userRepository.Save(BuildUser("R2D2", role2.Union(role3).ToList()));
        }

        private User BuildUser(string name, List<string> roles)
        {
            var sanitizeName = name.Replace(" ", "");
            return new User
            {
                Id = Guid.NewGuid(),
                Roles = roles,
                Name = name,
                UserEmail = $"{sanitizeName}@user.com",
                UserName = $"{sanitizeName}@user.com"
            };
        }
    }
}