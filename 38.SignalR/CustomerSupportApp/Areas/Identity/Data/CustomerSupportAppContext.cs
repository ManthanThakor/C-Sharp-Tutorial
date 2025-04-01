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


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


    }
}
