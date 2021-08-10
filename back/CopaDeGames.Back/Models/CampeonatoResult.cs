using System;
using CopaDeGames.Back.Domain.Entities;

namespace CopaDeGames.Back.Models
{
    public class CampeonatoResult
    {
        public CampeonatoResult(Campeonato campeonato)
        {
            Id = campeonato.Id;
            Campeao = new Vencedor(campeonato.Campeao.Titulo, campeonato.Campeao.UrlImagem);
            ViceCampeao = new Vencedor(campeonato.ViceCampeao.Titulo, campeonato.ViceCampeao.UrlImagem);        }

        public Guid Id { get; set; }
        public Vencedor Campeao { get; set; }
        public Vencedor ViceCampeao { get; set; }
    }
}
