using System;

namespace CopaDeGames.Back.Domain.Entities
{
    public class HistoricoCampeonato
    {
        public HistoricoCampeonato(Guid id, string campeao, string viceCampeao)
        {
            Id = id;
            Campeao = campeao;
            ViceCampeao = viceCampeao;
            DataCompeticao = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string Campeao { get; set; }
        public string ViceCampeao { get; set; }
        public DateTime DataCompeticao { get; set; }
    }
}
