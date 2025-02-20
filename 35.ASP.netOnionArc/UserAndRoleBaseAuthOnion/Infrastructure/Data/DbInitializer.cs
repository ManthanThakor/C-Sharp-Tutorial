// Infrastructure/Data/DbInitializer.cs
using Domain.Entity;
using Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
            var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger("DbInitializer");

            try
            {
                logger.LogInformation("Starting database initialization...");

                // Apply pending migrations
                await context.Database.MigrateAsync();
                logger.LogInformation("Migrations applied successfully");

                // Check if roles exist
                var roleCount = await context.Roles.CountAsync();
                logger.LogInformation($"Found {roleCount} existing roles in database");

                if (roleCount == 0)
                {
                    logger.LogInformation("Seeding roles to database...");

                    // Create roles with explicit IDs
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

                    // Add roles
                    context.Roles.Add(adminRole);
                    context.Roles.Add(userRole);

                    // Save changes
                    var saveResult = await context.SaveChangesAsync();
                    logger.LogInformation($"Saved {saveResult} roles to database");

                    // Verify roles were added
                    roleCount = await context.Roles.CountAsync();
                    logger.LogInformation($"After seeding: {roleCount} roles in database");
                }
                else
                {
                    logger.LogInformation("Roles already exist, skipping seed");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while initializing the database");
                throw; // Re-throw to make the error visible
            }
        }
    }
}