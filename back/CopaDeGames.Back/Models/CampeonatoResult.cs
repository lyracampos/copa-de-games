using System;
using CopaDeGames.Back.Domain.Entities;

namespace CopaDeGames.Back.Models
{
    public class CampeonatoResult
    {
        public CampeonatoResult(Campeonato campeonato)
        {
            Id = campeonato.Id;
            Campeao = campeonato.Campeao.Titulo;
            ViceCampeao = campeonato.ViceCampeao.Titulo;
        }

        public Guid Id { get; set; }
        public string Campeao { get; set; }
        public string ViceCampeao { get; set; }
    }
}
