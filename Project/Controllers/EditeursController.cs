using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Models.Repository;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EditeursController : ControllerBase
    {
        private readonly IEditeursRepository repository;

        public EditeursController(IEditeursRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Editeurs> e = await repository.GetEditeurs();

            return Ok(e);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            Editeurs e
                 = await repository.GetEditeursID(id);

            return Ok(e);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Editeurs ed)
        {
            Editeurs e = await repository.AddEditeurs(ed);
            if (e == null)
                return BadRequest("Problem");
            return CreatedAtAction(nameof(GetByID),
                new { id = e.EditeurID }, e);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var e = await repository.GetEditeursID(id);
            if (e == null)
            {
                return NotFound($"Editeurs with ID {id} not found.");
            }
            await repository.DeleteEditeurs(id);
            return Ok(e);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Editeurs updatedEditeurs)
        {
            var e = await repository.GetEditeursID(id);
            if (e == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }

            await repository.UpdateEditeurs(id, updatedEditeurs);

            return Ok(updatedEditeurs);
        }
    }
}
