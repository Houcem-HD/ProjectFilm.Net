using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Models.Repository;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LanguesController : ControllerBase
    {
        private readonly ILanguesRepository repository;

        public LanguesController(ILanguesRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Langues> l
                = await repository.GetLangues();

            return Ok(l);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            Langues l
                 = await repository.GetLanguesbyID(id);

            return Ok(l);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Langues lang)
        {
            Langues l = await repository.AddLangues(lang);
            if (l == null)
                return BadRequest("Problem");
            return CreatedAtAction(nameof(GetByID),
                new { id = l.LanguesID }, l);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var lang = await repository.GetLanguesbyID(id);
            if (lang == null)
            {
                return NotFound($"Langues with ID {id} not found.");
            }
            await repository.DeleteLangues(id);
            return Ok(lang);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Langues updatedLang)
        {
            var l = await repository.GetLanguesbyID(id);
            if (l == null)
            {
                return NotFound($"Langues with ID {id} not found.");
            }

            await repository.UpdateLangues(id, updatedLang);

            return Ok(updatedLang);
        }
    }
}
