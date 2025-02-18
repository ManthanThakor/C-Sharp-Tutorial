using Microsoft.EntityFrameworkCore;
using UserManagmentWebApi.Models;

namespace UserManagmentWebApi.Efcore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
