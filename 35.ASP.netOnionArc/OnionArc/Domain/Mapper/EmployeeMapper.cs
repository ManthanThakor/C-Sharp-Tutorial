using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapper
{
    public class EmployeeMapper : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> modelBuilder)
        {
            modelBuilder.HasKey(e => e.Id)
                .HasName("PK_EmployeeId");

            modelBuilder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("EmployeeID")
                .HasColumnType("INT");

            modelBuilder.Property(e => e.EmployeeName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("EmployeeName")
                .HasColumnType("Nvarchar(100)");

            modelBuilder.Property(e => e.DateOfJoin)
                .IsRequired()
                .HasColumnName("DateOfJoin")
                .HasColumnType("DATE");

            modelBuilder.Property(e => e.PhotoFilename)
                .HasMaxLength(255)
                .HasColumnName("PhotoFilename")
                .HasColumnType("Nvarchar(255)");
        }
    }
}
