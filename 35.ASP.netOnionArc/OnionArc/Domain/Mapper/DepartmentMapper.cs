using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mapper
{
    public class DepartmentMapper : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> modelBuilder)
        {
            modelBuilder.HasKey(d => d.Id)
                .HasName("PK_DepartmentId");

            modelBuilder.Property(d => d.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("DepartmentID")
                .HasColumnType("INT");

            modelBuilder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("DepartmentName")
                .HasColumnType("Nvarchar(150)");
        }
    }
}
