using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SimpleApi
{
    [ApiController]
    [Route("/api/books")]
    public class bookController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<BookDto>>> GetAll([FromServices]LibraryDbContext db)
        {
            var books = await db.Books.Select(b => new BookDto
            {
                ISBN = b.ISBN,
                Title = b.Title,
                Pages = b.Pages,
                Language = b.Language,
                Author = new AuthorDto
                {
                    Name = b.Author.Name,
                    ID = b.Author.ID
                }
            }).ToListAsync();
            return books;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> Get(string id, [FromServices]LibraryDbContext db)
        {
            var book = await db.Books.Where(b => b.ISBN == id).Select(b => new BookDto
            {
                ISBN = b.ISBN,
                Title = b.Title,
                Pages = b.Pages,
                Language = b.Language,
                Author = new AuthorDto
                {
                    Name = b.Author.Name,
                    ID = b.Author.ID
                }
            }).FirstOrDefaultAsync();
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        [HttpPost]
        public async Task Post(Book book, [FromServices]LibraryDbContext db)
        {
            db.Books.Add(book);
            await db.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id, [FromServices]LibraryDbContext db)
        {
            var book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}