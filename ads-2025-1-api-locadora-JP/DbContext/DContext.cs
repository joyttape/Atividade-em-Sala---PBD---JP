using ApiLocadora.Models;

namespace ApiLocadora.DbContext
{
    public static class DContext
    {
        public static List<Genero> ListaGenero { get; set; }
        public static List<Estudio> ListaEstudio { get; set; }
        public static List<Filme> ListaFilmes { get; set; }

        static DContext()
        {
            var acao = new Genero { Nome = "Ação" };
            var comedia = new Genero { Nome = "Comédia" };
            var drama = new Genero { Nome = "Drama" };

            ListaGenero = new List<Genero> { acao, comedia, drama };

            var warner = new Estudio { Nome = "Warner Bros", Distribuidor = "Warner Media" };
            var universal = new Estudio { Nome = "Universal Pictures", Distribuidor = "NBCUniversal" };

            ListaEstudio = new List<Estudio> { warner, universal };

            ListaFilmes = new List<Filme>
        {
            new Filme
            {
                Titulo = "Batman: O Cavaleiro das Trevas",
                Diretor = "Christopher Nolan",
                AnoLancamento = 2008,
                Avaliacao = 9.5,
                Estudio = warner,
                Generos = new List<Genero> { acao, drama }
            },
            new Filme
            {

                Titulo = "As Branquelas",
                Diretor = "Keenen Ivory Wayans",
                AnoLancamento = 2004,
                Avaliacao = 7.2,
                Estudio = universal,
                Generos = new List<Genero> { comedia }
            }
        };

        }
    }
}
