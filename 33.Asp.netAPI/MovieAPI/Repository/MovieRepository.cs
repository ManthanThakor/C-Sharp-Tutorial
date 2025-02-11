using MovieAPI.EfCore;
using MovieAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieAPI.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieAppDbContext _context;

        public MovieRepository(MovieAppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Movie> GetAll() => _context.Movies;

        public Movie? GetMovie(int id) => _context.Movies.FirstOrDefault(x => x.Id == id);

        public bool Exists(int id) => _context.Movies.Any(m => m.Id == id);

        public bool Exists(string title) =>
            _context.Movies.Any(m => m.Title.ToLower().Trim() == title.ToLower().Trim());

        public bool Add(Movie movie)
        {
            _context.Movies.Add(movie);
            return SaveChanges();
        }

        public bool Update(Movie movie)
        {
            _context.Movies.Update(movie);
            return SaveChanges();
        }

        public bool Remove(Movie movie)
        {
            _context.Movies.Remove(movie);
            return SaveChanges();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }
    }
}
