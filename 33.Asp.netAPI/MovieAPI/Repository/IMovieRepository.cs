using MovieAPI.Models;

namespace MovieAPI.Repository
{
    public interface IMovieRepository
    {
        IQueryable<Movie> GetAll();
        Movie? GetMovie(int id);
        bool Exists(int id);
        bool Exists(string title);
        bool Add(Movie movie);
        bool Update(Movie movie);
        bool Remove(Movie movie);
        bool SaveChanges();
    }
}
