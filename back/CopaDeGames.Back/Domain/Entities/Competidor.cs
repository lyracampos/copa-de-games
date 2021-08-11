namespace CopaDeGames.Back.Domain.Entities
{
    public class Competidor
    {
        /// <summary>
        /// competidor que disputa a competição de games
        /// </summary>
        /// <param name="id"></param>
        /// <param name="titulo"></param>
        /// <param name="nota"></param>
        /// <param name="ano"></param>
        /// <param name="urlImagem"></param>
        public Competidor(string id, string titulo, decimal nota, int ano, string urlImagem)
        {
            Id = id;
            Titulo = titulo;
            Nota = nota;
            Ano = ano;
            UrlImagem = urlImagem;
        }

        public string Id { get; private set; }
        public string Titulo { get; private set; }
        public decimal Nota { get; private set; }
        public int Ano { get; private set; }
        public string UrlImagem { get; private set; }
    }
}