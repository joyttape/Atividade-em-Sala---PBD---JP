using ApiLocadora.Dtos;
using ApiLocadora.Models;
using ApiLocadora.DbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace ApiLocadora.Controllers
{
        [Route("generos")]
        [ApiController]

        public class GeneroController : ControllerBase
        {
           
 
            [HttpGet] //lista todos
            public IActionResult BuscaGeneros()
            {
                return Ok(DContext.ListaGenero);
            }


            [HttpPost] //cadastrar

            public IActionResult CadastrarGenero([FromBody] GeneroDtos item)
            {

                var genero = new Genero();
                genero.Nome = item.Nome;

                DContext.ListaGenero.Add(genero);

                return Ok(DContext.ListaGenero);
            }


            [HttpPut("{id}")] //método Atualizar

            public IActionResult AtualizarGenero(Guid id, [FromBody] GeneroDtos item)
            {
                var genero = DContext.ListaGenero.FirstOrDefault(g => g.Id == id);

                if (genero == null)
                {

                return NotFound("Gênero não encontrado");
                }

                genero.Nome = item.Nome;
                return Ok("Gênero atualizado com sucesso!");
            }

            [HttpDelete("{id}")] //método Remover

            public IActionResult RemoverGenero(Guid id)
            {
               var genero = DContext.ListaGenero.FirstOrDefault(g => g.Id == id);

                if (genero == null)
                {

                return NotFound("Gênero não encontrado");
                }

                DContext.ListaGenero.Remove(genero);
                return Ok("Gênero removido com sucesso!");
            }

        }

    
}
