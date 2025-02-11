using EmpDepWebAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmpDepWebAPI.EfCore
{
    public class EmpDepDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public EmpDepDbContext(DbContextOptions<EmpDepDbContext> options) : base(options) { }

    }
}
