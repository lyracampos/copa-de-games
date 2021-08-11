using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CopaDeGames.Back.Domain.Entities;

namespace CopaDeGames.Back.Domain.Repositories.Data
{
    public interface ICampeonatoRepository
    {
        Task Adicionar(Competicao campeonato);

        Task<Competicao> Buscar(Guid id);

        Task<IEnumerable<Competicao>> Listar();
    }
}