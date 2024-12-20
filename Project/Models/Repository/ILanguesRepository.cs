namespace Project.Models.Repository
{
    public interface ILanguesRepository
    {
        Task<List<Langues>> GetLangues();

        Task<Langues> AddLangues(Langues lang);

        Task<Langues> GetLanguesbyID(int id);

        Task UpdateLangues(int id, Langues lang);

        Task DeleteLangues(int id);
    }
}
