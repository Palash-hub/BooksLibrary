using Books.Domain;
using Books.Infrastructure;
using Microsoft.AspNetCore.Mvc;


namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public AuthorsController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Author>>> Get()
        {
            return Ok(await _context.Authors.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> Get(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return BadRequest("Author not found. ");
            }
            return Ok(author);

        }

        [HttpPost]
        public async Task<ActionResult<List<Author>>> AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return Ok(await _context.Authors.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Author>>> UpdateAuthor(Author request)
        {
            var dbAuthor = await _context.Authors.FindAsync(request.id);
            if (dbAuthor == null)
            {
                return BadRequest("Author not found. ");
            }

            dbAuthor.FirstName = request.FirstName;
            dbAuthor.LastName = request.LastName;
            dbAuthor.Title = request.Title;
            
            await _context.SaveChangesAsync();

            return Ok(await _context.Authors.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<Author>> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return BadRequest("Author not found. ");
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return Ok(await _context.Authors.ToListAsync());

        }


    }
}
