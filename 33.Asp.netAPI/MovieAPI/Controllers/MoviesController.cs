using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MovieAPI.Models;
using MovieAPI.Repository;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // GET: api/movies
        [HttpGet]
        public ActionResult<IQueryable<Movie>> GetAllMovies()
        {
            var movies = _movieRepository.GetAll();
            if (movies == null || !movies.Any())
            {
                return NotFound("No movies found.");
            }
            return Ok(movies);
        }

        // GET: api/movies/{id}
        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovie(int id)
        {
            var movie = _movieRepository.GetMovie(id);
            if (movie == null)
            {
                return NotFound($"Movie with ID {id} not found.");
            }
            return Ok(movie);
        }

        // POST: api/movies
        [HttpPost]
        public ActionResult<Movie> CreateMovie(Movie movie)
        {
            if (_movieRepository.Exists(movie.Title))
            {
                return Conflict("A movie with this title already exists.");
            }

            var created = _movieRepository.Add(movie);
            if (!created)
            {
                return StatusCode(500, "There was an issue creating the movie.");
            }
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        // PUT: api/movies/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest("ID mismatch.");
            }

            if (!_movieRepository.Exists(id))
            {
                return NotFound($"Movie with ID {id} not found.");
            }

            var updated = _movieRepository.Update(movie);
            if (!updated)
            {
                return StatusCode(500, "There was an issue updating the movie.");
            }

            return NoContent();
        }

        // DELETE: api/movies/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            var movie = _movieRepository.GetMovie(id);
            if (movie == null)
            {
                return NotFound($"Movie with ID {id} not found.");
            }

            var deleted = _movieRepository.Remove(movie);
            if (!deleted)
            {
                return StatusCode(500, "There was an issue deleting the movie.");
            }

            return NoContent();
        }
    }
}
