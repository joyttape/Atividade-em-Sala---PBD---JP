using ApiLocadora.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiLocadora.Dtos
{
    public class FilmeDtos
    {

        [Required] public string Titulo { get; set; }

        [Required] public string Diretor { get; set; }

        [Required] public int AnoLancamento { get; set; }

        [Required] public double Avaliacao { get; set; }

        [Required] public List<Guid> GeneroId { get; set; }

        [Required] public Guid EstudioId { get; set; }

    }
}
