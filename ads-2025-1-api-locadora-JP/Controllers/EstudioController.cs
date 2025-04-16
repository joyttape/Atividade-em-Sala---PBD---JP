using ApiLocadora.Dtos;
using ApiLocadora.Models;
using ApiLocadora.DbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ApiLocadora.Controllers
{
        [Route("Estudios")]
        [ApiController]

        public class EstudioController : ControllerBase
        {
            
            [HttpGet] //lista todos
            public IActionResult BuscaEstudios
       ()
            {
                return Ok(DContext.ListaEstudio);
            }


            [HttpPost] //cadastrar

            public IActionResult CadastrarEstudio([FromBody] EstudioDtos item)
            {

                var estudio = new Estudio();
                estudio.Nome = item.Nome;
                estudio.Distribuidor = item.Distribuidor;

                DContext.ListaEstudio.Add(estudio);


            return Ok(DContext.ListaEstudio);
            }


            [HttpPut("{id}")] //método Atualizar

            public IActionResult AtualizarEstudio(Guid id, [FromBody] EstudioDtos item)
            {

                var estudio = DContext.ListaEstudio.FirstOrDefault(x => x.Id == id);

                if (estudio == null)
                {

                    return NotFound("Estudio não encontrado");
                }

                 estudio.Nome = item.Nome;
                 estudio.Distribuidor = item.Distribuidor;
                 return Ok("Estúdio atualizado com sucesso!");

            }

            [HttpDelete("{id}")] //método Remover

            public IActionResult RemoverEstudio(Guid id)
            {
                var estudio = DContext.ListaEstudio.FirstOrDefault(x => x.Id == id);

                if (estudio == null)
                {

                    return NotFound("Estúdio não encontrado");
                }

                DContext.ListaEstudio.Remove(estudio);
                return Ok("Estúdio removido com sucesso!");

            }

        }
}
