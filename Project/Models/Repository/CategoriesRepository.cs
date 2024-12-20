using Microsoft.EntityFrameworkCore;
using System;

namespace Project.Models.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly Context context;

        public CategoriesRepository(Context context)
        {
            this.context = context;
        }

        public async Task<Categories> AddCategories(Categories cat)
        {
            var result = await context.categories.AddAsync(cat);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteCategories(int id)
        {
            var Cat = await context.categories.FindAsync(id);
            context.categories.Remove(Cat);
            await context.SaveChangesAsync();
        }

        public async Task<List<Categories>> GetCategories()
        {
            List<Categories> cat=
                await context.categories.ToListAsync();
            return cat;
        }

        public async Task<Categories> GetCategoriesbyID(int id)
        {
            return await context.categories.FindAsync(id);
        }
        public async Task UpdateCategories(int id, Categories cat)
        {
            var existingCategory = await context.categories.FindAsync(id);

            existingCategory.nom = cat.nom;
            
            await context.SaveChangesAsync();
        }
    }
}
