using System;

namespace CopaDeGames.Back.Domain.Entities
{
    public class HistoricoCampeonato
    {
        public HistoricoCampeonato()
        {

        }
        public HistoricoCampeonato(Guid id, string campeao, string campeaoUrl, string viceCampeao, string viceCampeaoUrl)
        {
            Id = id;
            Campeao = campeao;
            CampeaoImg = campeaoUrl; 
            ViceCampeao = viceCampeao;
            ViceCampeaoImg = viceCampeaoUrl;
            DataCompeticao = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string Campeao { get; set; }
        public string CampeaoImg { get; set; }
        public string ViceCampeao { get; set; }
        public string ViceCampeaoImg { get; set; }
        public DateTime DataCompeticao { get; set; }
    }
}
