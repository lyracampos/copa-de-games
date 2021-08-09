using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaDeGames.Back.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CopaDeGames.Back.Domain.Repositories.Data
{
    public class CampeonatoRepository : ICampeonatoRepository
    {
        private readonly DataContext _context;

        public CampeonatoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Adicionar(HistoricoCampeonato campeonato)
        {
            try
            {
                await _context.Campeonatos.AddAsync(campeonato);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<HistoricoCampeonato> Buscar(Guid id) => await _context.Campeonatos.FindAsync(id);

        public async Task<IEnumerable<HistoricoCampeonato>> Listar() => await _context.Campeonatos.OrderBy(p => p.DataCompeticao).ToArrayAsync();
    }
}