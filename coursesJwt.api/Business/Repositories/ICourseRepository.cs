using coursesJwt.api.Business.Entities;

namespace coursesJwt.api.Business.Repositories
{
    public interface ICourseRepository
    {
        IList<Course> GetCourseByUser(int userId);

        void Add(Course course);

        void Commit();
    }
}
