using coursesJwt.api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace coursesJwt.api.Configurations
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<ProjectDbContext>
    {
        public ProjectDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectDbContext>();
            optionsBuilder.UseSqlServer("Server=.; Initial Catalog=CURSO; Encrypt=False; Integrated Security=True");
            ProjectDbContext context = new ProjectDbContext(optionsBuilder.Options);

            return context;
        }
    }
}
