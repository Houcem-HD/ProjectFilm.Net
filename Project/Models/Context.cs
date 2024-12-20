using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Project.Models
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Categories> categories { get; set; }
        public DbSet<Acteurs> acteurs{ get; set; }
        public DbSet<Editeurs> editeurs { get; set; }
        public DbSet<Langues> langues{ get; set; }
        public DbSet<Realisateurs> realisateurs{ get; set; }
        public DbSet<Film> films { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categories>().HasIndex(c => c.nom).IsUnique();
        }

    }
}
