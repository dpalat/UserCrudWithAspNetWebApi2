using System;
using System.Collections.Generic;
using UserCrud.Domain.Cryptography;
using UserCrud.Domain.DefaultData;
using UserCrud.Entity;
using UsersCrud.Repository;

namespace UserCrud.Domain
{
    public class UsersDomain : IUsersDomain
    {
        private readonly IRepository<User> _userRepository;
        private readonly IHasher _hasher;
        private const string _default_Password = "1234";

        public UsersDomain(IRepository<User> userRepository, ISeedUser seedUser, IHasher hasher)
        {
            _userRepository = userRepository;
            seedUser.Seed(_userRepository);

            _hasher = hasher;
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

        public void Delete(Guid Id)
        {
            _userRepository.Delete(Id);
        }

        public User Create(User user)
        {
            user.PasswordHash = _hasher.CalculateHash(_default_Password);
            _userRepository.Save(user);

            return user;
        }
    }
}