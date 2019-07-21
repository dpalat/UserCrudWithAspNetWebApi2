using System.Collections.Generic;
using UserCrud.Entity;

namespace UserCrud.Domain
{
    public interface IUsersDomain
    {
        IEnumerable<User> GetAll();
    }
}