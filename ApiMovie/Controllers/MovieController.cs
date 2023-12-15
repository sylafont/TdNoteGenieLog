using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/item")]
public class ItemController : ControllerBase
{
private readonly Movie _context;
public ItemController(Movie context)
{
_context = context;
}


// GET: api/item
[HttpGet]
public async Task<ActionResult<IEnumerable<Movie>>> GetItems()
{
// Get items
var items = _context.Movies; // Il y a un problème pour accéder à ma base de données qui fait qu'il ne reconait pas Movies
return await items.ToListAsync();
}

// GET: api/todo/2
[HttpGet("{id}")]
public async Task<ActionResult<Movie>> GetItem(int id)
{
// Find a specific item
// SingleAsync() throws an exception if no item is found (which is possible, depending on id)
// SingleOrDefaultAsync() is a safer choice here
var item = await _context.Movies.SingleOrDefaultAsync(t => t.Id == id);


if (item == null)
return NotFound();


return item;
}

[HttpPost]
public async Task<ActionResult<Movie>> PostItem(Movie item)
{
_context.Movies.Add(item);
await _context.SaveChangesAsync();


return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
}

// PUT: api/item/2
[HttpPut("{id}")]
public async Task<IActionResult> PutItem(int id, Movie item)
{
if (id != item.Id)
return BadRequest();


_context.Entry(item).State = EntityState.Modified;


try
{
await _context.SaveChangesAsync();
}
catch (DbUpdateConcurrencyException)
{
if (!_context.Movies.Any(m => m.Id == id))
return NotFound();
else
throw;
}


return NoContent();
}




}
