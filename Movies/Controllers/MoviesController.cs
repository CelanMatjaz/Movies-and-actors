using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MoviesService
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController(MoviesDbContext context) : Controller
    {
        private readonly MoviesDbContext _context = context;

        [HttpGet("{id}")]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        [HttpGet]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies(int? pageSize, int? page, string search = "")
        {
            var query = _context.Movies.AsQueryable();

            if (search != "")
            {
                query = query.Where(m => m.Title.ToLower().Contains(search.ToLower()));
            }

            if (pageSize.HasValue && page.HasValue)
            {
                if (pageSize < 1 || page < 1)
                {
                    return BadRequest();
                }

                query = query.Skip((int)((page - 1) * pageSize)).Take((int)pageSize);
            }

            return await query.OrderBy(x => x.Id).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            var newMovie = new Movie
            {
                Title = movie.Title,
                Year = movie.Year,
                Description = movie.Description,
                ListOfActors = movie.ListOfActors,
                ImageLink = movie.ImageLink
            };

            _context.Movies.Add(newMovie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(newMovie), new { id = newMovie.Id }, newMovie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            var foundMovie = await _context.Movies.FindAsync(id);
            if (foundMovie == null)
            {
                return NotFound();
            }

            foundMovie.Title = movie.Title;
            foundMovie.Year = movie.Year;
            foundMovie.Description = movie.Description;
            foundMovie.ListOfActors = movie.ListOfActors;
            foundMovie.ImageLink = movie.ImageLink;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!MovieExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var foundMovie = await _context.Movies.FindAsync(id);
            if (foundMovie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(foundMovie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }

    }
}
