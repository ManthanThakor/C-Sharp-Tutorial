using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("CartId");

            builder.HasOne(c => c.Product)
                   .WithMany(p => p.Carts)
                   .HasForeignKey(c => c.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
