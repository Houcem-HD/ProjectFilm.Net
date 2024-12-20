using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using Project.Models;
using Project.Models.Repository;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository repository;

        public CategoriesController(ICategoriesRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Categories> cats
                = await repository.GetCategories();

            return Ok(cats);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            Categories cats
                 = await repository.GetCategoriesbyID(id);

            return Ok(cats);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Categories cats)
        {
            Categories cat = await repository.AddCategories(cats);
            if (cat == null)
                return BadRequest("Problem");
            return CreatedAtAction(nameof(GetByID),
                new { id = cat.CategorieID }, cat);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await repository.GetCategoriesbyID(id);
            if (category == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            await repository.DeleteCategories(id);
            return Ok(category);
            
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Categories updatedCategory)
        {
            var category = await repository.GetCategoriesbyID(id);
            if (category == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }

            await repository.UpdateCategories(id, updatedCategory);

            return Ok(updatedCategory);
        }
    }
}
