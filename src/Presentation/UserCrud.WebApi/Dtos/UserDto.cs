using System;
using System.Collections.Generic;

namespace UserCrud.WebApi.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string UserEmail { get; set; }
        public string UserToken { get; set; }
        public List<string> Roles { get; set; }
    }
}