using Domain.Entity;
using Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            await context.Database.MigrateAsync();

            if (!await context.Roles.AnyAsync())
            {
                var adminRole = new Role
                {
                    Id = Guid.Parse("8D04DCE2-969A-435D-BBA4-DF3F325983DC"),
                    Name = "Admin",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                var userRole = new Role
                {
                    Id = Guid.Parse("3D04DCE2-969A-435D-BBA4-DF3F325983DC"),
                    Name = "User",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                context.Roles.AddRange(adminRole, userRole);
                await context.SaveChangesAsync();
            }
        }
    }
}
