using CopaDeGames.Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace CopaDeGames.Back.Domain.Repositories.Data
{
    public class CampeonatoDataContext : DbContext
    {
        public CampeonatoDataContext()
        {

        }

        public CampeonatoDataContext(DbContextOptions<CampeonatoDataContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "CopaDeGames");
        }

        public DbSet<Competicao> Competicoes { get; set; }
    }
}
