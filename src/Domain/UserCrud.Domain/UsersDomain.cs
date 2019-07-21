using System.Collections.Generic;
using UserCrud.Domain.DefaultData;
using UserCrud.Entity;
using UsersCrud.Repository;

namespace UserCrud.Domain
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IRepository<User> _userRepository;

        public UsersDomain(IRepository<User> userRepository, ISeedUser seedUser)
        {
            _userRepository = userRepository;
            seedUser.Seed(_userRepository);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.List();
        }
    }
}