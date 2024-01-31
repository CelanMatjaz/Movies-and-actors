using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ActorsService;

[Route("api/[controller]")]
[ApiController]
public class ActorsController(ActorsDbContext context) : Controller
{
    private readonly ActorsDbContext _context = context;

    [HttpGet]
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
    public async Task<ActionResult<IEnumerable<Actor>>> GetActors(string? q, int? pageSize, int? page)
    {
        var query = context.Actors;

        if (pageSize != null && page != null)
        {
            query.Skip((int)(Math.Floor((double)page.GetValueOrDefault(0)) * pageSize.GetValueOrDefault(1))).Take(pageSize.GetValueOrDefault(1));
        }

        if (q != null)
        {
            query.Where(a => a.FirstName.ToLower().Contains(q.ToLower()) || a.LastName.ToLower().Contains(q.ToLower()));
        }

        return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
    public async Task<ActionResult<Actor>> GetActor(int id)
    {
        var actor = await _context.Actors.FindAsync(id);

        if (actor == null)
        {
            return NotFound();
        }

        return actor;
    }

    [HttpPost]
    public async Task<ActionResult<Actor>> PostActor(Actor actor)
    {
        var newActor = new Actor
        {
            FirstName = actor.FirstName,
            LastName = actor.LastName,
            BornDate = actor.BornDate,
            ListOfMovies = actor.ListOfMovies
        };

        _context.Actors.Add(newActor);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(newActor), new { id = newActor.Id }, newActor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutActor(int id, Actor actor)
    {
        if (id != actor.Id)
        {
            return BadRequest();
        }

        var foundActor = await _context.Actors.FindAsync(id);
        if (foundActor == null)
        {
            return NotFound();
        }

        foundActor.FirstName = actor.FirstName;
        foundActor.LastName = actor.LastName;
        foundActor.BornDate = actor.BornDate;
        foundActor.ListOfMovies = actor.ListOfMovies;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!ActorExists(id))
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActor(int id)
    {
        var foundActor = await _context.Actors.FindAsync(id);
        if (foundActor == null)
        {
            return NotFound();
        }

        _context.Actors.Remove(foundActor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ActorExists(int id)
    {
        return _context.Actors.Any(e => e.Id == id);
    }

}
