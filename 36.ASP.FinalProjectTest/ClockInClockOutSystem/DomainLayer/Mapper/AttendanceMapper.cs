using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DomainLayer.Mapper
{
    public class AttendanceMapper : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> modelBuilder)
        {
            modelBuilder.HasKey(a => a.Id)
                .HasName("PK_AttendanceId");

            modelBuilder.Property(a => a.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("AttendanceID")
                .HasColumnType("UniqueIdentifier");

            modelBuilder.Property(a => a.CheckInTime)
                .IsRequired()
                .HasColumnType("DATETIME2");

            modelBuilder.Property(a => a.CheckOutTime)
                .HasColumnType("DATETIME2");

            modelBuilder.Property(a => a.EmployeeId)
                .IsRequired()
                .HasColumnType("UniqueIdentifier");
        }
    }
}
