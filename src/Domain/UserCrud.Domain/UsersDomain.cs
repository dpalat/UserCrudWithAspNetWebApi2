using System;
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

        public User Get(Guid Id)
        {
            return _userRepository.FindById(Id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.List();
        }

        public User Update(User user)
        {
            _userRepository.Save(user);

            return user;
        }
    }
}