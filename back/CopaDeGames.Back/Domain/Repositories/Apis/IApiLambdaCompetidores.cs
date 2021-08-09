using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CopaDeGames.Back.Domain.Entities;

namespace CopaDeGames.Back.Domain.Repositories.Apis
{
    public interface IApiLambdaCompetidores
    {
        string UrlApi { get; }
        Task<IEnumerable<Competidor>> BuscarCompetidores();
    }
}