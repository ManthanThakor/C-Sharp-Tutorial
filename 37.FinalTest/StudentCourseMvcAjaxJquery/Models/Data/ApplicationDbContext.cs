
using Microsoft.EntityFrameworkCore;
using StudentCourseMvcAjaxJquery.Models.Entity;
using StudentCourseMvcAjaxJquery.Models.Mapper;

namespace StudentCourseMvcAjaxJquery.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new StudentMapper());
            modelBuilder.ApplyConfiguration(new CourseMapper());
            modelBuilder.ApplyConfiguration(new EnrollmentMapper());
        }
    }
}
