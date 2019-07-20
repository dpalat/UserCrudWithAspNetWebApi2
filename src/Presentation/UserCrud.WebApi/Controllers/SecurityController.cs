using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UserCrud.WebApi.Dtos;
using UserCrud.WebApi.Models;

namespace UserCrud.WebApi.Controllers
{
    public class SecurityController : System.Web.Http.ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("LogIn")]
        public UserDto LogIn([System.Web.Http.FromBody]LoginDto loginDto)
        {
            string user = loginDto.UserName;
            string password = loginDto.Password;
            var userDto = new UserDto
            {
                Id = Guid.NewGuid(),
                UserName = user,
                UserEmail = user,
                Roles = new List<string>() { "ADMIN" }
            };

            return userDto;
        }
    }
}