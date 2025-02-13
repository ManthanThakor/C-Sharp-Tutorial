using Microsoft.EntityFrameworkCore;
using UserAuthMVC.Models;

namespace UserAuthMVC.EFcore
{
    public class CookieContext : DbContext
    {
        public CookieContext(DbContextOptions options) : base(options)
        { }
        public DbSet<CookieUser> Users { get; set; }
    }
}
