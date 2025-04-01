using CustomerSupportApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomerSupportApp.Data;

public class CustomerSupportAppContext : IdentityDbContext<IdentityUser>
{
    public CustomerSupportAppContext(DbContextOptions<CustomerSupportAppContext> options)
        : base(options)
    {
    }
    public DbSet<ChatRoom> ChatRooms { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ChatMessage>()
              .HasOne(c => c.ChatRoom)
              .WithMany(c => c.Messages)
              .HasForeignKey(c => c.ChatRoomId)
              .OnDelete(DeleteBehavior.Cascade);
    }
}
