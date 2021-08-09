using System.Collections.Generic;
using System.Threading.Tasks;
using CopaDeGames.Back.Domain.Entities;

namespace CopaDeGames.Back.Domain.Services
{
    public interface ICampeonatoService
    {
        Task<Campeonato> IniciarCampeonato(string[] idCompetidores);
    }
}
