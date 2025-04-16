using System.ComponentModel.DataAnnotations;

namespace ApiLocadora.Dtos
{
    public class GeneroDtos
    {
        [Required] public string Nome { get; set; }
    }
}
