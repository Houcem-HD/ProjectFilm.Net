using Microsoft.EntityFrameworkCore;

namespace Project.Models.Repository
{
    public class LanguesRepository : ILanguesRepository
    {
        private readonly Context context;

        public LanguesRepository(Context context)
        {
            this.context = context;
        }

        public async Task<Langues> AddLangues(Langues l)
        {
            var result = await context.langues.AddAsync(l);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteLangues(int id)
        {
            var l = await context.langues.FindAsync(id);
            context.langues.Remove(l);
            await context.SaveChangesAsync();
        }

        public async Task<List<Langues>> GetLangues()
        {
            List<Langues> l =
                await context.langues.ToListAsync();
            return l;
        }

        public async Task<Langues> GetLanguesbyID(int id)
        {
            return await context.langues.FindAsync(id);
        }
        public async Task UpdateLangues(int id, Langues l)
        {
            var existingLang = await context.langues.FindAsync(id);

            existingLang.langues = l.langues;

            await context.SaveChangesAsync();
        }
    }
}
