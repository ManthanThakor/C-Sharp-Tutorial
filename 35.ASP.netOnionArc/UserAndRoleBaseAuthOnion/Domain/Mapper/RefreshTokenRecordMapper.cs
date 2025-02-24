using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Mapper
{
    public class RefreshTokenRecordMapper : IEntityTypeConfiguration<RefreshTokenRecord>
    {
        public void Configure(EntityTypeBuilder<RefreshTokenRecord> modelBuilder)
        {
            modelBuilder.HasKey(rt => rt.Token)
                .HasName("PK_RefreshToken");

            modelBuilder.Property(rt => rt.Token)
                .IsRequired()
                .HasColumnType("NVARCHAR(MAX)");

            modelBuilder.Property(rt => rt.ExpiryTime)
                .IsRequired()
                .HasColumnName("ExpiryTime");

            modelBuilder.Property(rt => rt.IsRevoked)
                .HasColumnName("IsRevoked")
                .HasDefaultValue(false);

            modelBuilder.Property(rt => rt.RevokedReason)
                .HasColumnType("NVARCHAR(500)");

            modelBuilder.Property(rt => rt.CreatedAt)
                .IsRequired()
                .HasColumnName("CreatedAt");

            modelBuilder.Property(rt => rt.ReplacedByToken)
                .HasColumnType("NVARCHAR(MAX)");

            modelBuilder.Property(rt => rt.DeviceInfo)
                .HasColumnType("NVARCHAR(255)");

            modelBuilder.Property(rt => rt.IpAddress)
                .HasColumnType("NVARCHAR(50)");

            modelBuilder.Property(rt => rt.UserId)
                .IsRequired()
                .HasColumnName("UserID");

            modelBuilder.HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
