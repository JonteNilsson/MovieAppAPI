using Microsoft.AspNetCore.Mvc;
using MovieAPPwithAPI.Models;

namespace MovieAPPwithAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        public static List<Movie> Movies { get; set; } = new()
        {
            new Movie { Id = 1, Title = "Inception", ProductionYear = 2010, Genre = "Sci-Fi", BoxOffice = "$829M", Synopsis = "A thief enters the dreams of others to steal their deepest secrets." },
            new Movie { Id = 2, Title = "The Shawshank Redemption", ProductionYear = 1994, Genre = "Drama", BoxOffice = "$28M", Synopsis = "Two imprisoned men bond over several years, finding solace and eventual redemption through acts of common decency." },
            new Movie { Id = 3, Title = "The Dark Knight", ProductionYear = 2008, Genre = "Action", BoxOffice = "$1B", Synopsis = "Batman faces a new foe, The Joker, who seeks chaos in Gotham City." },
            new Movie { Id = 4, Title = "Forrest Gump", ProductionYear = 1994, Genre = "Drama", BoxOffice = "$678M", Synopsis = "A man with a low IQ witnesses and unwittingly influences several defining historical events in the 20th century." },
            new Movie { Id = 5, Title = "The Godfather", ProductionYear = 1972, Genre = "Crime", BoxOffice = "$135M", Synopsis = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." },
            new Movie { Id = 6, Title = "The Matrix", ProductionYear = 1999, Genre = "Sci-Fi", BoxOffice = "$463M", Synopsis = "A computer hacker learns about the true nature of his reality and his role in the war against its controllers." },
            new Movie { Id = 7, Title = "Jurassic Park", ProductionYear = 1993, Genre = "Adventure", BoxOffice = "$1B", Synopsis = "A theme park featuring genetically engineered dinosaurs turns into a deadly nightmare." },
            new Movie { Id = 8, Title = "Titanic", ProductionYear = 1997, Genre = "Romance", BoxOffice = "$2.2B", Synopsis = "A romance between two passengers aboard the ill-fated maiden voyage of the Titanic." },
            new Movie { Id = 9, Title = "Pulp Fiction", ProductionYear = 1994, Genre = "Crime", BoxOffice = "$214M", Synopsis = "The lives of two mob hitmen, a boxer, a gangster's wife, and a pair of diner bandits intertwine in four tales of violence and redemption." },
            new Movie { Id = 10, Title = "Avatar", ProductionYear = 2009, Genre = "Fantasy", BoxOffice = "$2.79B", Synopsis = "A paraplegic marine dispatched to the moon Pandora on a unique mission becomes torn between following orders and protecting an alien civilization." }
        };

        [HttpGet]
        public ActionResult<List<Movie>> Get()
        {
            if (Movies != null)
            {
                return Ok(Movies);
            }

            return NotFound("Movies cant be found");
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            var movie = Movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                return Ok(movie);
            }

            return NotFound("Cant find movie with that ID");

        }

        [HttpPost]
        public ActionResult<Movie> Post(Movie movie)
        {
            if (movie != null)
            {
                Movies.Add(movie);
                return Ok("Movie added");
            }

            return BadRequest("Could not add movie, check inputs and try again!");
        }

        [HttpPut]
        [Route("{id}")]
        [Consumes("application/json")]
        public ActionResult Put(int id, Movie updatedMovie)
        {
            var existingMovie = Movies.FirstOrDefault(m => m.Id == id);

            if (existingMovie == null)
            {
                return NotFound("Cant find movie");
            }

            existingMovie.Title = updatedMovie.Title;
            existingMovie.ProductionYear = updatedMovie.ProductionYear;
            existingMovie.Synopsis = updatedMovie.Synopsis;
            existingMovie.BoxOffice = updatedMovie.BoxOffice;
            existingMovie.Id = id;
            existingMovie.Genre = updatedMovie.Genre;

            return Ok("Movie updated");
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var movieToDelete = Movies.FirstOrDefault(m => m.Id == id);
            if (movieToDelete == null)
            {
                return NotFound();
            }

            Movies.Remove(movieToDelete);

            return Ok("Movie deleted");
        }

    };


}
