using System.Linq;
using CopaDeGames.Back.Domain.Entities;
using CopaDeGames.Back.Tests.UnitTests.Mocks;
using Xunit;

namespace CopaDeGames.Back.Tests.UnitTests.Domain.Entities
{
    public class CampeonatoTests
    {
        [Fact]
        public void CampeonatoDeveSerDisputadoComSucesso()
        {
            // arr
            var competidores = MockCompetidores.Competidores().Take(8).ToList();
            var campeonato = new Campeonato(competidores);
            var competidorComMaiorNota = competidores.OrderBy(p => p.Nota).FirstOrDefault();
            var competidorComSegundaMaiorNota = competidores.OrderBy(p => p.Nota).ToArray()[1];

            // act
            campeonato.IniciarCompeticao();

            // ass
            Assert.NotNull(campeonato.Campeao);
            Assert.NotNull(campeonato.ViceCampeao);
        }
    }
}
