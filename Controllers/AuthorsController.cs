using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Data;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Model;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ApplicationDbContext dbcontext;

        public AuthorsController(ApplicationDbContext context)
        {
            dbcontext= context;
        }

        
        [HttpGet]
        [Route("RetrieveAuthorDetails")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await dbcontext.Author.ToListAsync();
        }

       
        [HttpPost]
        [Route("AddNewAuthor")]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {

            dbcontext.Author.Add(author);
            await dbcontext.SaveChangesAsync();
            return author;
          
        }        
    }
}

