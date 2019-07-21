using System;
using System.Collections.Generic;
using UserCrud.Entity;

namespace UserCrud.Domain
{
    public interface IUsersDomain
    {
        IEnumerable<User> GetAll();
        User Get(Guid Id);
        User Update(User user);
        User Create(User user);
        void Delete(Guid Id);
    }
}