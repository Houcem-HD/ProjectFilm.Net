using Microsoft.AspNetCore.Mvc;
using Project.Models.Repository;
using Project.Models;
using Microsoft.AspNetCore.Authorization;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RealisateursController : ControllerBase
    {
        private readonly IRealisateursRepository repository;

        public RealisateursController(IRealisateursRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Realisateurs> res
                = await repository.GetRealisateurs();

            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            Realisateurs res
                 = await repository.GetRealisateursbyID(id);

            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Realisateurs res)
        {
            Realisateurs r = await repository.AddRealisateurs(res);
            if (r == null)
                return BadRequest("Problem");
            return CreatedAtAction(nameof(GetByID),
                new { id = r.RealisateursID }, r);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await repository.GetRealisateursbyID(id);
            if (res == null)
            {
                return NotFound($"Realisateur with ID {id} not found.");
            }
            await repository.DeleteRealisateurs(id);
            return Ok(res);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Realisateurs updatedRes)
        {
            var res = await repository.GetRealisateursbyID(id);
            if (res == null)
            {
                return NotFound($"Realisateur with ID {id} not found.");
            }

            await repository.UpdateRealisateurs(id, updatedRes);

            return Ok(updatedRes);
        }
    }
}
