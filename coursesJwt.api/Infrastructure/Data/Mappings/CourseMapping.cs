using coursesJwt.api.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace coursesJwt.api.Infrastructure.Data.Mappings
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("TB_COURSE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Descripton);
            builder.HasOne(p => p.User).WithMany().HasForeignKey(fk => fk.UserId);
        }
    }
}
