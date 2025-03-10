using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentCourseMvcAjaxJquery.Models.Entity;

namespace StudentCourseMvcAjaxJquery.Models.Mapper
{
    public class StudentMapper : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> modelBuilder)
        {
            modelBuilder.HasKey(s => s.Id)
                .HasName("PK_StudentId");

            modelBuilder.Property(s => s.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("StudentID")
                .HasColumnType("INT");

            modelBuilder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR(50)");

            modelBuilder.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR(100)");

            modelBuilder.Property(s => s.Address)
                .HasMaxLength(200)
                .HasColumnName("Address")
                .HasColumnType("NVARCHAR(200)");

            modelBuilder.Property(s => s.DOB)
                .HasColumnName("DOB")
                .HasColumnType("DATE");

            modelBuilder.HasMany(s => s.Enrollments)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
