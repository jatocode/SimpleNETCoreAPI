using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace SimpleApi
{
    [ApiController]
    [Route("/api/books")]
    public class bookController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAll([FromServices]LibraryDbContext db)
        {
            var books = await db.Book.ToListAsync();
            var authors = await db.Author.ToListAsync(); // For debug
            return books;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(long id, [FromServices]LibraryDbContext db)
        {
            var book = await db.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        [HttpPost]
        public async Task Post(Book book, [FromServices]LibraryDbContext db)
        {
            db.Book.Add(book);
            db.Author.Add(book.Author);
            await db.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id, [FromServices]LibraryDbContext db)
        {
            var book = await db.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Book.Remove(book);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}