using CopaDeGames.Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace CopaDeGames.Back.Domain.Repositories.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "CopaDeGames");
        }

        public DbSet<HistoricoCampeonato> Campeonatos { get; set; }
    }
}
