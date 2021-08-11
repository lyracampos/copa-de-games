using Xunit;
using CopaDeGames.Back.Domain.Entities;

namespace CopaDeGames.Back.Tests.UnitTests.Domain.Entities
{
    public class PartidaTests
    {
        [Fact]
        public void Competidor1DeveGanharPorNota()
        {
            // arr
            var competidor1 = new Competidor("compeditor-a", "titulo competidor a", new decimal(99.9), 1992, "imgs/compeditora");
            var competidor2 = new Competidor("compeditor-b", "titulo competidor b", new decimal(92.1), 2020, "imgs/compeditorb");
            var partida = new Partida(competidor1, competidor2);

            // act
            partida.Disputar();

            // ass
            Assert.Equal(TipoDeVitoria.Nota, partida.TipoDeVitoria);
            Assert.Equal(partida.Vencedor, competidor1);
        }

        [Fact]
        public void Competidor2DeveGanharPorNota()
        {
            // arr
            var competidor1 = new Competidor("compeditor-a", "titulo competidor a", new decimal(99.8), 1992, "imgs/compeditora");
            var competidor2 = new Competidor("compeditor-b", "titulo competidor b", new decimal(99.9), 2020, "imgs/compeditorb");
            var partida = new Partida(competidor1, competidor2);

            // act
            partida.Disputar();

            // ass
            Assert.Equal(TipoDeVitoria.Nota, partida.TipoDeVitoria);
            Assert.Equal(partida.Vencedor, competidor2);
        }

        [Fact]
        public void Competidor1DeveGanharPorAno()
        {
            // arr
            var competidor1 = new Competidor("compeditor-a", "titulo competidor a", new decimal(99.9), 2021, "imgs/compeditora");
            var competidor2 = new Competidor("compeditor-b", "titulo competidor b", new decimal(99.9), 2020, "imgs/compeditorb");
            var partida = new Partida(competidor1, competidor2);

            // act
            partida.Disputar();

            // ass
            Assert.Equal(TipoDeVitoria.Ano, partida.TipoDeVitoria);
            Assert.Equal(partida.Vencedor, competidor1);
        }

        [Fact]
        public void Competidor2DeveGanharPorAno()
        {
            // arr
            var competidor1 = new Competidor("compeditor-a", "titulo competidor a", new decimal(99.8), 1992, "imgs/compeditora");
            var competidor2 = new Competidor("compeditor-b", "titulo competidor b", new decimal(99.8), 2020, "imgs/compeditorb");
            var partida = new Partida(competidor1, competidor2);

            // act
            partida.Disputar();

            // ass
            Assert.Equal(TipoDeVitoria.Ano, partida.TipoDeVitoria);
            Assert.Equal(partida.Vencedor, competidor2);
        }

        [Fact]
        public void Competidor1DeveGanharPorOrdemAlfabetica()
        {
            // arr
            var competidor1 = new Competidor("compeditor-a", "titulo competidor a", new decimal(99.8), 2020, "imgs/compeditora");
            var competidor2 = new Competidor("compeditor-b", "titulo competidor b", new decimal(99.8), 2020, "imgs/compeditorb");
            var partida = new Partida(competidor1, competidor2);

            // act
            partida.Disputar();

            // ass
            Assert.Equal(TipoDeVitoria.OrderAlfabetica, partida.TipoDeVitoria);
            Assert.Equal(partida.Vencedor, competidor1);
        }

        [Fact]
        public void Competidor2DeveGanharPorOrdemAlfabetica()
        {
            // arr
            var competidor1 = new Competidor("compeditor-a", "titulo competidor b", new decimal(99.8), 2020, "imgs/compeditora");
            var competidor2 = new Competidor("compeditor-b", "titulo competidor a", new decimal(99.8), 2020, "imgs/compeditorb");
            var partida = new Partida(competidor1, competidor2);

            // act
            partida.Disputar();

            // ass
            Assert.Equal(TipoDeVitoria.OrderAlfabetica, partida.TipoDeVitoria);
            Assert.Equal(partida.Vencedor, competidor2);
        }
    }
}
