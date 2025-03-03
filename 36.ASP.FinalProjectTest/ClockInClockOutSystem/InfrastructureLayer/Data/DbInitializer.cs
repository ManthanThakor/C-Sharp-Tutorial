using DomainLayer.Entity;
using InfrastructureLayer.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context, IPasswordService passwordService)
        {
            context.Database.Migrate();

            if (!context.Employees.Any(e => e.Role == "Admin"))
            {
                var admin = new Employee
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    Email = "admin@gmail.com",
                    PasswordHash = passwordService.HashPassword("Admin@123"),
                    Role = "Admin"
                };

                context.Employees.Add(admin);
                context.SaveChanges();
            }
        }
    }
}