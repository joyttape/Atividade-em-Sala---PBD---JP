using System.ComponentModel.DataAnnotations;

namespace ApiLocadora.Dtos
{
    public class EstudioDtos
    {
        [Required] public string Nome { get; set; }
        [Required] public string Distribuidor { get; set; }
    }
}
