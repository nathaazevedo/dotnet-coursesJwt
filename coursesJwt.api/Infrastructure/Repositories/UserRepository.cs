using coursesJwt.api.Business.Entities;
using coursesJwt.api.Business.Repositories;
using coursesJwt.api.Infrastructure.Data;

namespace coursesJwt.api.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ProjectDbContext _context;

        public UserRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public User GetUser(string login)
        {
            return _context.Users.FirstOrDefault(u => u.Login == login);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }
        
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
