﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaDeGames.Back.Domain.Entities
{
    /// <summary>
    /// classe realizado do campeonato. organiza as chaves, rodadas, partidas e competidores
    /// </summary>
    public class Campeonato
    {
        public Guid Id { get; private set; }
        public List<Competidor> Competidores { get; private set; }
        public Vencedor Campeao { get; private set; }
        public Vencedor ViceCampeao { get; private set; }

        public Campeonato(List<Competidor> competidores)
        {
            Id = Guid.NewGuid();
            Competidores = competidores;
        }

        public void IniciarCompeticao()
        {
            PrepararChaveamentoInicial();

            var competidoresClassificados = Competidores;

            while (competidoresClassificados.Count > 1)
            {
                var partidas = PartidasDaRodada(competidoresClassificados);

                if (partidas != null)
                    partidas.ForEach(p => { p.Disputar(); });

                competidoresClassificados = partidas.Select(p => p.Vencedor).ToList();

                if (partidas.Count == 1)
                {
                    var ultimaPartida = partidas.FirstOrDefault();
                    Campeao = new Vencedor(ultimaPartida.Vencedor.Id, ultimaPartida.Vencedor.Titulo, ultimaPartida.Vencedor.UrlImagem);
                    ViceCampeao = new Vencedor(ultimaPartida.Perdedor.Id, ultimaPartida.Perdedor.Titulo, ultimaPartida.Perdedor.UrlImagem);
                }
            }
        }

        /// <summary>
        /// prepara chaveamento inicial do campeonato, de modo que o primeiro competidor jogue com o último e assim por diante.
        /// </summary>
        private void PrepararChaveamentoInicial()
        {
            var competidoresOrdemAlfabetica = Competidores.OrderBy(p => p.Titulo).ToList();
            Competidores = new List<Competidor>();

            while (competidoresOrdemAlfabetica.Count() > 0)
            {
                var competidor1 = competidoresOrdemAlfabetica.FirstOrDefault();
                var competidor2 = competidoresOrdemAlfabetica.LastOrDefault();
                competidoresOrdemAlfabetica.Remove(competidor1);
                Competidores.Add(competidor1);
                competidoresOrdemAlfabetica.Remove(competidor2);
                Competidores.Add(competidor2);
            }
        }

        /// <summary>
        /// prepara uma rodade de partidas com os competidores que ainda estão classificados no campeonato
        /// </summary>
        /// <param name="competidoresClassificados"></param>
        /// <returns></returns>
        private List<Partida> PartidasDaRodada(List<Competidor> competidoresClassificados)
        {
            var partidas = new List<Partida>();
            var skip = 0;
            while (competidoresClassificados.Count() != (partidas.Count * 2))
            {
                var competidoresPartida = competidoresClassificados.Skip(skip).Take(2);
                partidas.Add(new Partida(competidoresPartida.FirstOrDefault(), competidoresPartida.LastOrDefault()));
                skip += 2;
            }
            return partidas;
        }
    }
}
