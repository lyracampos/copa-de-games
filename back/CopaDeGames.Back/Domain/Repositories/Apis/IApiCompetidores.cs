using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CopaDeGames.Back.Domain.Entities;

namespace CopaDeGames.Back.Domain.Repositories.Apis
{
    /// <summary>
    /// api para consultar competidores. (chamadas para api externa da lambda).
    /// </summary>
    public interface IApiCompetidores
    {
        string UrlApi { get; }
        Task<IEnumerable<Competidor>> BuscarCompetidores();
    }
}