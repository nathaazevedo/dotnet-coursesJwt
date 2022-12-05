using coursesJwt.api.Business.Entities;

namespace coursesJwt.api.Business.Repositories
{
    public interface IUserRepository
    {
        User GetUser(string login);

        void Add(User user);

        void Commit();
    }
}
