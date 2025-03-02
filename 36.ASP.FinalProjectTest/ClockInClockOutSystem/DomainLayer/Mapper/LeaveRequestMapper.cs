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
    public class LeaveRequestMapper : IEntityTypeConfiguration<LeaveRequest>
    {
        public void Configure(EntityTypeBuilder<LeaveRequest> modelBuilder)
        {
            modelBuilder.HasKey(l => l.Id)
                .HasName("PK_LeaveRequestId");

            modelBuilder.Property(l => l.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("LeaveRequestID")
                .HasColumnType("UniqueIdentifier");

            modelBuilder.Property(l => l.EmployeeId)
                .IsRequired()
                .HasColumnType("UniqueIdentifier");

            modelBuilder.Property(l => l.StartDate)
                .IsRequired()
                .HasColumnType("DATETIME2");

            modelBuilder.Property(l => l.EndDate)
                .IsRequired()
                .HasColumnType("DATETIME2");

            modelBuilder.Property(l => l.Reason)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("NVARCHAR(500)");

            modelBuilder.Property(l => l.Status)
                .IsRequired()
                .HasConversion<string>()
                .HasColumnType("NVARCHAR(50)");
        }
    }
}
