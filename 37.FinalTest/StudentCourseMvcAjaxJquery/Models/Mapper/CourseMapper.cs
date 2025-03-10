using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCourseMvcAjaxJquery.Models.Entity;

namespace StudentCourseMvcAjaxJquery.Models.Mapper
{
    public class CourseMapper : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> modelBuilder)
        {
            modelBuilder.HasKey(c => c.Id)
                .HasName("PK_CourseId");

            modelBuilder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("CourseID")
                .HasColumnType("INT");

            modelBuilder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Title")
                .HasColumnType("NVARCHAR(100)");

            modelBuilder.Property(c => c.Description)
                .HasMaxLength(500)
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR(500)");

            modelBuilder.HasMany(c => c.Enrollments)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
