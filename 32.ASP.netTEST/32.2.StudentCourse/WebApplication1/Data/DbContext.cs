using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Students> Students { get; set; }
    public DbSet<Course> Courses { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Course>()
            .HasOne(c => c.Student)
            .WithMany(s => s.Courses)
            .HasForeignKey(c => c.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
