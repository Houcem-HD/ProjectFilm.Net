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
    public class ActeursController : ControllerBase
    {
        private readonly IActeursRepository repository;

        public ActeursController(IActeursRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Acteurs> a = await repository.GetActeurs();

            return Ok(a);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            Acteurs a
                 = await repository.GetActeursID(id);

            return Ok(a);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Acteurs act)
        {
            Acteurs a = await repository.AddActeurs(act);
            if (a == null)
                return BadRequest("Problem");
            return CreatedAtAction(nameof(GetByID),
                new { id = a.ActeurID }, a);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var a = await repository.GetActeursID(id);
            if (a == null)
            {
                return NotFound($"Acteur with ID {id} not found.");
            }
            await repository.DeleteActeurs(id);
            return Ok(a);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Acteurs updatedActeurs)
        {
            var a = await repository.GetActeursID(id);
            if (a == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }

            await repository.UpdateActeurs(id, updatedActeurs);

            return Ok(updatedActeurs);
        }
    }
}
