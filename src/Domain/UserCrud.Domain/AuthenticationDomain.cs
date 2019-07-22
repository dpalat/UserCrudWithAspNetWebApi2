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
            var user = _userRepository.List().Where(e => e.UserEmail.ToLowerInvariant() == userEmail.ToLowerInvariant()).FirstOrDefault();

            var passwordHash = _hasher.CalculateHash(password);

            if (user.PasswordHash == passwordHash) return user;

            return null;
        }
    }
}