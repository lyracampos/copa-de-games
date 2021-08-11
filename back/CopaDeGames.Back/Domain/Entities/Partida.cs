using System.Collections.Generic;
using System.Linq;

namespace CopaDeGames.Back.Domain.Entities
{
    public class Partida
    {
        /// <summary>
        /// classe para realizar uma disputa entre dois competidores
        /// </summary>
        /// <param name="competidor1"></param>
        /// <param name="competidor2"></param>
        public Partida(Competidor competidor1, Competidor competidor2)
        {
            Competidor1 = competidor1;
            Competidor2 = competidor2;
        }
        public Competidor Competidor1 { get; private set; }
        public Competidor Competidor2 { get; private set; }
        public Competidor Vencedor { get; private set; }
        public Competidor Perdedor { get; private set; }
        public TipoDeVitoria TipoDeVitoria { get; private set; }


        public void Disputar()
        {
            CompetirPorNota();

            if (Vencedor == null)
                DesempatarPorAnoDeLancamento();

            if (Vencedor == null)
                DesempatarPorOrdemAlfabetica();
        }

        private void CompetirPorNota()
        {
            if (Competidor1.Nota > Competidor2.Nota)
            {
                Vencedor = Competidor1;
                Perdedor = Competidor2;
            }
            else if (Competidor1.Nota < Competidor2.Nota)
            {
                Vencedor = Competidor2;
                Perdedor = Competidor1;
            }
            
            if (Vencedor != null)
                TipoDeVitoria = TipoDeVitoria.Nota;
        }

        private void DesempatarPorAnoDeLancamento()
        {
            if (Competidor1.Ano > Competidor2.Ano)
            {
                Vencedor = Competidor1;
                Perdedor = Competidor2;
            }
            else if (Competidor1.Ano < Competidor2.Ano)
            {
                Vencedor = Competidor2;
                Perdedor = Competidor1;
            }

            if (Vencedor != null)
                TipoDeVitoria = TipoDeVitoria.Ano;
        }

        private void DesempatarPorOrdemAlfabetica()
        {
            var competidores = new List<Competidor>() { Competidor1, Competidor2 };
            Vencedor = competidores.OrderBy(p => p.Titulo).FirstOrDefault();
            Perdedor = competidores.OrderByDescending(p => p.Titulo).FirstOrDefault();
            TipoDeVitoria = TipoDeVitoria.OrderAlfabetica;
        }
    }

    public enum TipoDeVitoria
    {
        Nota,
        Ano,
        OrderAlfabetica
    }
}
