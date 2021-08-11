using System;

namespace CopaDeGames.Back.Domain.Entities
{
    public class Vencedor
    {
        /// <summary>
        /// classe com informações do vencedor do campeonato
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="urlImagem"></param>
        public Vencedor(string id, string titulo, string urlImagem)
        {
            Id = id;
            Titulo = titulo;
            UrlImagem = urlImagem;
        }

        public string Id { get; set; }
        public string Titulo { get; set; }
        public string UrlImagem { get; set; }
    }
}
