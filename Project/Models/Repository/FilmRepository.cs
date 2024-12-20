using Microsoft.EntityFrameworkCore;

namespace Project.Models.Repository
{
    public class FilmRepository : IFilmRepository
    {
        private readonly Context context;

        public FilmRepository(Context context)
        {
            this.context = context;
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
            context.films.Remove(res);
            await context.SaveChangesAsync();
        }

        public async Task<List<Film>> GetFilm()
        {
            List<Film> res =
                await context.films.ToListAsync();
            return res;
        }

        public async Task<Film> GetFilmbyID(int id)
        {
            return await context.films.FindAsync(id);
        }
        public async Task UpdateFilm(int id, Film film)
        {
            var existingfilm = await context.films.FindAsync(id);

            existingfilm.Nom = film.Nom;
            existingfilm.Description = film.Description;
            existingfilm.DateCreated = film.DateCreated;
            existingfilm.Duree = film.Duree;
            existingfilm.Poster = film.Poster;
            existingfilm.CategorieID = film.CategorieID;
            existingfilm.ActeurPID = film.ActeurPID;
            existingfilm.ActeurSID = film.ActeurSID;
            existingfilm.EditeurID = film.EditeurID;
            existingfilm.LangueID = film.LangueID;
            existingfilm.RealisateurID = film.RealisateurID;

            await context.SaveChangesAsync();
        }
    }
}
