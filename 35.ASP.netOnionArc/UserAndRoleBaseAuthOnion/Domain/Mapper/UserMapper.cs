using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mapper
{
    public class UserMapper : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.HasKey(u => u.Id)
                .HasName("PK_UserId");

            modelBuilder.Property(u => u.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("UserID")
                .HasColumnType("UniqueIdentifier");

            modelBuilder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Username")
                .HasColumnType("NVARCHAR(100)");

            modelBuilder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR(200)");

            modelBuilder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasColumnName("PasswordHash")
                .HasColumnType("NVARCHAR(MAX)");

            modelBuilder.Property(u => u.RoleId)
                .IsRequired()
                .HasColumnName("RoleID")
                .HasColumnType("UniqueIdentifier");

            modelBuilder.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
