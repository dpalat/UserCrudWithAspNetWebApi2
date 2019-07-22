using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCrud.Entity;

namespace UserCrud.Domain
{
    public interface IAuthenticationDomain
    {
        User LogInUser(string userEmail, string password);
    }
}
