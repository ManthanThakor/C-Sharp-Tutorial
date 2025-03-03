using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Mapper
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
                .HasColumnType("UniqueIdentifier");

            modelBuilder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("NVARCHAR(150)");

            modelBuilder.HasMany(e => e.Attendances)
                .WithOne(a => a.Employee)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.HasMany(e => e.LeaveRequests)
                .WithOne(l => l.Employee)
                .HasForeignKey(l => l.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
