
using LibraryManagement.Data;
using LibraryManagement.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext context2;

        public CategoriesController(ApplicationDbContext context)
        {
            context2 = context;
        }


        [HttpGet]
        [Route("RetrieveCategoriesList")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            
            return await context2.Category.ToListAsync();
        }


        [HttpPost]
        [Route("AddNewcategory")]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            context2.Category.Add(category);
            await context2.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategories), new { id = category.Id }, category);
        }
    }
}

