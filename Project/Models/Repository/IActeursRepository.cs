namespace Project.Models.Repository
{
    public interface IActeursRepository
    {
        Task<List<Acteurs>> GetActeurs();

        Task<Acteurs> AddActeurs(Acteurs a);

        Task<Acteurs> GetActeursID(int id);

        Task UpdateActeurs(int id, Acteurs a);

        Task DeleteActeurs(int id);
    }
}
