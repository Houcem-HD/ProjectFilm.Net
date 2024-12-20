using Microsoft.EntityFrameworkCore;

namespace Project.Models.Repository
{
    public class RealisateursRepository : IRealisateursRepository
    {
        private readonly Context context;

        public RealisateursRepository(Context context)
        {
            this.context = context;
        }

        public async Task<Realisateurs> AddRealisateurs(Realisateurs res)
        {
            var result = await context.realisateurs.AddAsync(res);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteRealisateurs(int id)
        {
            var res = await context.realisateurs.FindAsync(id);
            context.realisateurs.Remove(res);
            await context.SaveChangesAsync();
        }

        public async Task<List<Realisateurs>> GetRealisateurs()
        {
            List<Realisateurs> res =
                await context.realisateurs.ToListAsync();
            return res;
        }

        public async Task<Realisateurs> GetRealisateursbyID(int id)
        {
            return await context.realisateurs.FindAsync(id);
        }
        public async Task UpdateRealisateurs(int id, Realisateurs res)
        {
            var existingresegory = await context.realisateurs.FindAsync(id);

            existingresegory.nom = res.nom;

            await context.SaveChangesAsync();
        }
    }
}
