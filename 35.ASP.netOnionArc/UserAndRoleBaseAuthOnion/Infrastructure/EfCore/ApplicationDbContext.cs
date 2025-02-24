using Domain.Entity;
using Domain.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EfCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RefreshTokenRecord> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMapper());
            modelBuilder.ApplyConfiguration(new RoleMapper());
            modelBuilder.ApplyConfiguration(new RefreshTokenRecordMapper());
        }
    }
}
