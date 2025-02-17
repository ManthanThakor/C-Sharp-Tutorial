using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductManageMvc.Areas.Identity.Data;

namespace ProductManageMvc.Data;

public class ProductManageMvcContext : IdentityDbContext<ProductManageMvcUser>
{
    public ProductManageMvcContext(DbContextOptions<ProductManageMvcContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
