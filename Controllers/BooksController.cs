using LibraryManagement.Data;
using LibraryManagement.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext context1;

        public BooksController(ApplicationDbContext context)
        {
            context1 = context;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var Books= await context1.Book
           // return await context1.Book
                .Include(b => b.AuthorId)
                .Include(b => b.CategoryId)

               
            .Select(b => new Book
    {
        Id = b.Id,
        Title = b.Title,
        Description = b.Description,
        PublicationYear = b.PublicationYear,
        AuthorId = b.AuthorId,
        CategoryId = b.CategoryId
    })
    .ToListAsync();
            return Books;
               
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            context1.Book.Add(book);
            await context1.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await context1.Book
                .Include(b => b.AuthorId)
                .Include(b => b.CategoryId)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }


        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteBook(int id)
        {
            var book = context1.Book.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            context1.Book.Remove(book);
            context1.SaveChanges();
            return Ok(book);
        }
    }
}
