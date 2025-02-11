using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.EfCore
{
    public class MovieAppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options) : base(options)
        {

        }
    }
}
