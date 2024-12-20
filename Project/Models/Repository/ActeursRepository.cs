using Microsoft.EntityFrameworkCore;

namespace Project.Models.Repository
{
    public class ActeursRepository : IActeursRepository
    {
        private readonly Context context;

        public ActeursRepository(Context context)
        {
            this.context = context;
        }

        public async Task<Acteurs> AddActeurs(Acteurs a)
        {
            var result = await context.acteurs.AddAsync(a);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteActeurs(int id)
        {
            var a = await context.acteurs.FindAsync(id);
            context.acteurs.Remove(a);
            await context.SaveChangesAsync();
        }

        public async Task<List<Acteurs>> GetActeurs()
        {
            List<Acteurs> a = await context.acteurs.ToListAsync();
            return a;
        }

        public async Task<Acteurs> GetActeursID(int id)
        {
            return await context.acteurs.FindAsync(id);
        }
        public async Task UpdateActeurs(int id, Acteurs a)
        {
            var existingActeurs = await context.acteurs.FindAsync(id);

            existingActeurs.nom = a.nom;
            existingActeurs.prenom = a.prenom;
            existingActeurs.date_naissance = a.date_naissance;
            existingActeurs.nationalite = a.nationalite;

            await context.SaveChangesAsync();
        }
    }
}
