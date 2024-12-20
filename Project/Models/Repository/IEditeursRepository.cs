namespace Project.Models.Repository
{
    public interface IEditeursRepository
    {
        Task<List<Editeurs>> GetEditeurs();

        Task<Editeurs> AddEditeurs(Editeurs a);

        Task<Editeurs> GetEditeursID(int id);

        Task UpdateEditeurs(int id, Editeurs a);

        Task DeleteEditeurs(int id);
    }
}
