using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mapper
{
    public class RoleMapper : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> modelBuilder)
        {
            modelBuilder.HasKey(r => r.Id)
                .HasName("PK_RoleId");

            modelBuilder.Property(r => r.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("RoleID")
                .HasColumnType("UniqueIdentifier");

            modelBuilder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("RoleName")
                .HasColumnType("NVARCHAR(150)");
        }
    }
}
