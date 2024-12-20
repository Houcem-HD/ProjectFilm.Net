using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Project.Models.Repository
{
    public class FilmRepository : IFilmRepository
    {
        private readonly Context context;
        private readonly IWebHostEnvironment _env;

        public FilmRepository(Context context, IWebHostEnvironment env)
        {
            this.context = context;
            this._env = env;
        }

        public async Task<Film> AddFilm(Film film)
        {
            var result = await context.films.AddAsync(film);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteFilm(int id)
        {
            var res = await context.films.FindAsync(id);
            if (res != null)
            {
                context.films.Remove(res);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Film>> GetFilm()
        {
            return await context.films.ToListAsync();
        }

        public async Task<Film> GetFilmbyID(int id)
        {
            return await context.films.FindAsync(id);
        }

        public async Task UpdateFilm(int id, Film film)
        {
            var existingFilm = await context.films.FindAsync(id);
            if (existingFilm == null)
            {
                throw new FileNotFoundException("Film not found.");
            }

            existingFilm.Nom = film.Nom;
            existingFilm.Description = film.Description;
            existingFilm.DateCreated = film.DateCreated;
            existingFilm.Duree = film.Duree;
            existingFilm.Poster = film.Poster;
            existingFilm.CategorieID = film.CategorieID;
            existingFilm.ActeurPID = film.ActeurPID;
            existingFilm.ActeurSID = film.ActeurSID;
            existingFilm.EditeurID = film.EditeurID;
            existingFilm.LangueID = film.LangueID;
            existingFilm.RealisateurID = film.RealisateurID;

            await context.SaveChangesAsync();
        }

        public async Task<string> UploadFilmPosterAsync(int filmId, IFormFile file)
        {
            var film = await context.films.FindAsync(filmId);
            if (film == null)
            {
                throw new FileNotFoundException("Film not found.");
            }

            if (file == null || file.Length == 0 || !new[] { "image/png", "image/jpeg", "image/jpg" }.Contains(file.ContentType))
            {
                throw new Exception("Invalid file.");
            }

            var uploadsDirectory = Path.Combine(_env.ContentRootPath, "wwwroot", "images");
            if (!Directory.Exists(uploadsDirectory))
            {
                Directory.CreateDirectory(uploadsDirectory);
            }

            var fileExtension = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{fileExtension}";
            var fullFilePath = Path.Combine(uploadsDirectory, fileName);

            using (var stream = new FileStream(fullFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            film.Poster = $"images/{fileName}";
            context.Entry(film).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return film.Poster;
        }
    }
}
