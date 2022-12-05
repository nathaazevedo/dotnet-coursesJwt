using coursesJwt.api.Business.Entities;
using coursesJwt.api.Business.Repositories;
using coursesJwt.api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace coursesJwt.api.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ProjectDbContext _context;

        public CourseRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public IList<Course> GetCourseByUser(int userId)
        {
            return _context.Courses.Include(u => u.User).Where(c => c.UserId == userId).ToList();
        }

        public void Add(Course course)
        {
            _context.Courses.Add(course);
        }
        
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
