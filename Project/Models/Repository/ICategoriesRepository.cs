namespace Project.Models.Repository
{
    public interface ICategoriesRepository
    {
        Task<List<Categories>> GetCategories();

        Task<Categories> AddCategories(Categories cat);

        Task<Categories> GetCategoriesbyID(int id);

        Task UpdateCategories(int id, Categories cat);

        Task DeleteCategories(int id);
    }
}
