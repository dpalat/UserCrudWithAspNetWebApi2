using System;
using System.Collections.Generic;
using UsersCrud.Repository;

namespace UserCrud.Entity
{
    public class User : ISearchable
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Name { get; set; }
        public string UserToken { get; set; }
        public List<string> Roles { get; set; }
        public string PasswordHash { get; set; }
    }
}