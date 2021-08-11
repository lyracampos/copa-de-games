using System;
using CopaDeGames.Back.Domain.Entities;

namespace CopaDeGames.Back.Models
{
    public class CampeonatoResult
    {
        public CampeonatoResult()
        {

        }
        public CampeonatoResult(Campeonato campeonato)
        {
            Id = campeonato.Id;
            Campeao = new Vencedor(Id.ToString(), campeonato.Campeao.Titulo, campeonato.Campeao.UrlImagem);
            ViceCampeao = new Vencedor(Id.ToString(), campeonato.ViceCampeao.Titulo, campeonato.ViceCampeao.UrlImagem);        }

        public Guid Id { get; set; }
        public Vencedor Campeao { get; set; }
        public Vencedor ViceCampeao { get; set; }
    }
}
