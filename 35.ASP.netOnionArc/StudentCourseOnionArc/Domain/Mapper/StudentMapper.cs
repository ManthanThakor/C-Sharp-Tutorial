using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapper
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

            modelBuilder.Property(s => s.CourseId)
                .HasColumnName("CourseID")
                .HasColumnType("INT");
        }
    }
}
