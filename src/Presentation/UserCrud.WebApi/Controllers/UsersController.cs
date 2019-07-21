using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using UserCrud.Domain;
using UserCrud.WebApi.Dtos;

namespace UserCrud.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private IUsersDomain _usersDomain;

        public UsersController(IUsersDomain usersDomain)
        {
            _usersDomain = usersDomain;
        }

        // GET: api/Users
        public IEnumerable<UserDto> Get()
        {
            _usersDomain.GetAll();
            var users = new List<UserDto>();
            var baseRoles1 = new List<string> { "PAGE_1", "PAGE_2" };
            var baseRoles2 = new List<string> { "ADMIN", "PAGE_2" };
            users.Add(new UserDto { Id = Guid.NewGuid(), Roles = baseRoles1, UserEmail = "1@gmail.com", UserName = "1@gmail.com" });
            users.Add(new UserDto { Id = Guid.NewGuid(), Roles = baseRoles1, UserEmail = "2@gmail.com", UserName = "2@gmail.com" });
            users.Add(new UserDto { Id = Guid.NewGuid(), Roles = baseRoles2, UserEmail = "3@gmail.com", UserName = "3@gmail.com" });
            users.Add(new UserDto { Id = Guid.NewGuid(), Roles = baseRoles2, UserEmail = "4@gmail.com", UserName = "4@gmail.com" });
            return users;
        }

        // GET: api/Users/5
        public UserDto Get(string id)
        {
            return Get().FirstOrDefault();
        }
    }
}