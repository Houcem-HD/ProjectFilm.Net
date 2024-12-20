namespace Project.Models.Repository
{
    public interface IRealisateursRepository
    {
        Task<List<Realisateurs>> GetRealisateurs();

        Task<Realisateurs> AddRealisateurs(Realisateurs res);

        Task<Realisateurs> GetRealisateursbyID(int id);

        Task UpdateRealisateurs(int id, Realisateurs res);

        Task DeleteRealisateurs(int id);
    }
}
