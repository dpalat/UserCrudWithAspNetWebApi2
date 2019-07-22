using System.Linq;
using UserCrud.Domain.Cryptography;
using UserCrud.Entity;
using UsersCrud.Repository;

namespace UserCrud.Domain
{
    public class AuthenticationDomain : IAuthenticationDomain
    {
        private readonly IRepository<User> _userRepository;
        private readonly IHasher _hasher;

        public AuthenticationDomain(IRepository<User> userRepository, IHasher hasher)
        {
            _userRepository = userRepository;
            _hasher = hasher;
        }

        public User LogInUser(string userEmail, string password)
        {
            if (string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(password)) return null;

            var user = _userRepository.List().Where(e => e.UserEmail.ToLowerInvariant() == userEmail.ToLowerInvariant()).FirstOrDefault();
            if (user == null) return null;

            var passwordHash = _hasher.CalculateHash(password);

            if (user.PasswordHash == passwordHash) return user;

            return null;
        }
    }
}