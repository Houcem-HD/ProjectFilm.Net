using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Models.Repository;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FilmController : ControllerBase
    {
        private readonly IFilmRepository repository;

        public FilmController(IFilmRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Film> f = await repository.GetFilm();
            return Ok(f);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            Film l = await repository.GetFilmbyID(id);
            return Ok(l);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Film film)
        {
            if (film == null)
                return BadRequest("Invalid payload");

            Film f = await repository.AddFilm(film);
            if (f == null)
                return BadRequest("Problem adding the film");

            return CreatedAtAction(nameof(GetByID), new { id = f.FilmID }, f);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var film = await repository.GetFilmbyID(id);
            if (film == null)
            {
                return NotFound($"Film with ID {id} not found.");
            }
            await repository.DeleteFilm(id);
            return Ok(film);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Film updatedfilm)
        {
            var f = await repository.GetFilmbyID(id);
            if (f == null)
            {
                return NotFound($"Film with ID {id} not found.");
            }

            await repository.UpdateFilm(id, updatedfilm);

            return Ok(updatedfilm);
        }

        [HttpPost("uploadPoster")]
        public async Task<IActionResult> UploadFilmPoster(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { message = "No file selected." });
            }

            try
            {
                var uploadedFilePath = await repository.UploadFilmPosterAsync(file);
                return Ok(new { message = "Film poster updated successfully.", posterUrl = uploadedFilePath });
            }
            catch (FileNotFoundException)
            {
                return NotFound(new { message = "Film not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
            }
        }
    }
}