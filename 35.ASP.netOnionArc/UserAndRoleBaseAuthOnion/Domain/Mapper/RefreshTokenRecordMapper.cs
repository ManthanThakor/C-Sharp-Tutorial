using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mapper
{
    public class RefreshTokenRecordMapper : IEntityTypeConfiguration<RefreshTokenRecord>
    {
        public void Configure(EntityTypeBuilder<RefreshTokenRecord> modelBuilder)
        {
            // Set the primary key to Id
            modelBuilder.HasKey(rt => rt.Id)
                .HasName("PK_RefreshToken");

            // Configure Token as a required unique field
            modelBuilder.Property(rt => rt.Token)
                .IsRequired()
                .HasColumnType("NVARCHAR(512)")
                .HasMaxLength(512);

            modelBuilder.HasIndex(rt => rt.Token) // Ensure uniqueness
                .IsUnique();

            // ExpiryTime
            modelBuilder.Property(rt => rt.ExpiryTime)
                .IsRequired()
                .HasColumnName("ExpiryTime");

            // IsRevoked
            modelBuilder.Property(rt => rt.IsRevoked)
                .HasColumnName("IsRevoked")
                .HasDefaultValue(false);

            // RevokedReason
            modelBuilder.Property(rt => rt.RevokedReason)
                .HasColumnType("NVARCHAR(500)")
                .HasMaxLength(500)
                .IsRequired(false);

            // CreatedAt
            modelBuilder.Property(rt => rt.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt");

            // ReplacedByToken
            modelBuilder.Property(rt => rt.ReplacedByToken)
                .HasColumnType("NVARCHAR(512)")
                .HasMaxLength(512)
                .IsRequired(false);

            // DeviceInfo
            modelBuilder.Property(rt => rt.DeviceInfo)
                .HasColumnType("NVARCHAR(255)")
                .HasMaxLength(255)
                .IsRequired(false);

            // IpAddress
            modelBuilder.Property(rt => rt.IpAddress)
                .HasColumnType("NVARCHAR(50)")
                .HasMaxLength(50)
                .IsRequired(false);

            // UserID Foreign Key
            modelBuilder.Property(rt => rt.UserId)
                .IsRequired()
                .HasColumnName("UserID");

            // Define Relationship with User
            modelBuilder.HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
