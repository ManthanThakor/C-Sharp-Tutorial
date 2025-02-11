using EmpDepWebAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmpDepWebAPI.EfCore
{
    public class EmpDepDbContext : DbContext
    {
        public EmpDepDbContext(DbContextOptions<EmpDepDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId);
        }
    }
}
