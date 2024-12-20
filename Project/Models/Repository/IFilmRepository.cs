namespace Project.Models.Repository
{
    public interface IFilmRepository
    {
        Task<List<Film>> GetFilm();
        Task<Film> AddFilm(Film film);

        Task<Film> GetFilmbyID(int id);

        Task UpdateFilm(int id, Film film);

        Task DeleteFilm(int id);
    }
}
