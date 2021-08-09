using System;
using System.Collections.Generic;
using System.Linq;
using CopaDeGames.Back.Domain.Entities;
using CopaDeGames.Back.Tests.Mocks;
using Xunit;

namespace CopaDeGames.Back.Tests.Domain.Entities
{
    public class CampeonatoTests
    {
        [Fact]
        public void Campeonato()
        {
            // arr
            var competidores = MockCompetidores.Competidores().Take(8).ToList();
            var campeonato = new Campeonato(competidores);

            // act
            campeonato.IniciarCompeticao();

            // ass

            Assert.True(false);
        }

        
    }
}
