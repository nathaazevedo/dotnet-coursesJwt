using coursesJwt.api.Business.Entities;
using coursesJwt.api.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace coursesJwt.api.Infrastructure.Data
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
