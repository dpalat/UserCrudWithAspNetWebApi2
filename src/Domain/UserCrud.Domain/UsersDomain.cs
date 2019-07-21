using System.Collections;
using System.Collections.Generic;
using UserCrud.Entity;
using UsersCrud.Repository;

namespace UserCrud.Domain
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IRepository<User> _userRepository;

        public UsersDomain(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.List();
        }
    }
}