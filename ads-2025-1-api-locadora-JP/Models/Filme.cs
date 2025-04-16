namespace ApiLocadora.Models
{
    public class Filme
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Titulo { get; set; }
        public string Diretor { get; set; }

        public int AnoLancamento {  get; set; }

        public double Avaliacao { get; set; }

        public List <Genero> Generos { get; set; }

        public Estudio Estudio { get; set; }

    }
}
