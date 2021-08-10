using System;
using System.Linq;
using System.Threading.Tasks;
using CopaDeGames.Back.Domain.Entities;
using CopaDeGames.Back.Domain.Repositories.Apis;
using CopaDeGames.Back.Domain.Repositories.Data;

namespace CopaDeGames.Back.Domain.Services
{
    public class CampeonatoService : ICampeonatoService
    {
        private readonly ICampeonatoRepository _campeonatoRepository;
        private readonly IApiLambdaCompetidores _apiLambdaCompetidores;


        public CampeonatoService(ICampeonatoRepository campeonatoRepository, IApiLambdaCompetidores apiLambdaCompetidores)
        {
            _campeonatoRepository = campeonatoRepository;
            _apiLambdaCompetidores = apiLambdaCompetidores;
        }

        public async Task<Campeonato> IniciarCampeonato(string[] idCompetidores)
        {
            // competidores da api lambda.
            var competidores = await _apiLambdaCompetidores.BuscarCompetidores();

            // filtra apenas competidores recebido no request
            competidores = competidores.Where(p => idCompetidores.Contains(p.Id));

            // roda inicia campeonato
            var campeonato = new Campeonato(competidores.ToList());
            campeonato.IniciarCompeticao();

            // salva campeonato no banco
            await _campeonatoRepository.Adicionar(new HistoricoCampeonato(campeonato.Id, campeonato.Campeao.Titulo, campeonato.Campeao.UrlImagem, campeonato.ViceCampeao.Titulo, campeonato.ViceCampeao.UrlImagem));

            return campeonato;
        }
    }
}
