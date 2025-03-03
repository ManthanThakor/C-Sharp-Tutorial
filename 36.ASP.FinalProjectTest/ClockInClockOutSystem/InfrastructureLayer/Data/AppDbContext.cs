using DomainLayer.Entity;
using Microsoft.EntityFrameworkCore;
using DomainLayer.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AttendanceMapper());
            modelBuilder.ApplyConfiguration(new EmployeeMapper());
            modelBuilder.ApplyConfiguration(new LeaveRequestMapper());

            base.OnModelCreating(modelBuilder);
        }
    }
}