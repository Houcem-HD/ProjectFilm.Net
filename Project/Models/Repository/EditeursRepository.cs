using Microsoft.EntityFrameworkCore;

namespace Project.Models.Repository
{
    public class EditeursRepository : IEditeursRepository
    {
        private readonly Context context;

        public EditeursRepository(Context context)
        {
            this.context = context;
        }

        public async Task<Editeurs> AddEditeurs(Editeurs e)
        {
            var result = await context.editeurs.AddAsync(e);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteEditeurs(int id)
        {
            var e = await context.editeurs.FindAsync(id);
            context.editeurs.Remove(e);
            await context.SaveChangesAsync();
        }

        public async Task<List<Editeurs>> GetEditeurs()
        {
            List<Editeurs> e = await context.editeurs.ToListAsync();
            return e;
        }

        public async Task<Editeurs> GetEditeursID(int id)
        {
            return await context.editeurs.FindAsync(id);
        }
        public async Task UpdateEditeurs(int id, Editeurs a)
        {
            var existingEditeur = await context.editeurs.FindAsync(id);

            existingEditeur.nom = a.nom;
            existingEditeur.prenom = a.prenom;
            existingEditeur.nationalite = a.nationalite;
            existingEditeur.date_naissance = a.date_naissance;

            await context.SaveChangesAsync();
        }
    }
}
