using UserCrud.Entity;
using UsersCrud.Repository;

namespace UserCrud.Domain.DefaultData
{
    public interface ISeedUser
    {
        void Seed(IRepository<User> userRepository);
    }
}