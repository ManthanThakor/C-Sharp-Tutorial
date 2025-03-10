using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCourseMvcAjaxJquery.Models.Entity;

namespace StudentCourseMvcAjaxJquery.Models.Mapper
{
    public class EnrollmentMapper : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> modelBuilder)
        {
            modelBuilder.HasKey(e => e.Id)
                .HasName("PK_EnrollmentId");

            modelBuilder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("EnrollmentID")
                .HasColumnType("INT");

            modelBuilder.Property(e => e.StudentId)
                .HasColumnName("StudentID")
                .HasColumnType("INT");

            modelBuilder.Property(e => e.CourseId)
                .HasColumnName("CourseID")
                .HasColumnType("INT");

            modelBuilder.Property(e => e.EnrollmentDate)
                .HasColumnName("EnrollmentDate")
                .HasColumnType("DATE");

            modelBuilder.HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
