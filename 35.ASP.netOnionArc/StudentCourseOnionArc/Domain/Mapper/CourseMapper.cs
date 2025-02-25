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
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR(500)");

            modelBuilder.HasMany(c => c.Students)
               .WithOne(s => s.Course)
               .HasForeignKey(s => s.CourseId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
