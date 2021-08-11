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
        private readonly CampeonatoDataContext _context;

        public CampeonatoRepository(CampeonatoDataContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Competicao campeonato)
        {
            try
            {
                await _context.Competicoes.AddAsync(campeonato);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<Competicao> Buscar(Guid id) => await _context.Competicoes.FindAsync(id);

        public async Task<IEnumerable<Competicao>> Listar() => await _context.Competicoes.OrderBy(p => p.DataCompeticao).ToArrayAsync();
    }
}