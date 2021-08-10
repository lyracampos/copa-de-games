namespace CopaDeGames.Back.Domain.Entities
{
    public class Vencedor
    {
        public Vencedor(string titulo, string urlImagem)
        {
            Titulo = titulo;
            UrlImagem = urlImagem;
        }

        public string Titulo { get; set; }
        public string UrlImagem { get; set; }
    }
}
