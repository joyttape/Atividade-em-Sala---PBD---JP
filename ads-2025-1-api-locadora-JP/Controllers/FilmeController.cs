using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiLocadora.Dtos;
using ApiLocadora.Models;
using ApiLocadora.DbContext;

namespace ApiLocadora.Controllers
{
    [Route("filmes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
       
        [HttpGet] //principal
        public IActionResult BuscaFilmes()
        {
            return Ok(DContext.ListaFilmes);
        }


        [HttpPost]

        public IActionResult CadastrarFilme([FromBody] FilmeDtos item)
        {

            var estudio = DContext.ListaEstudio.FirstOrDefault(e => e.Id == item.EstudioId);
            var genero = DContext.ListaGenero.Where(g => item.GeneroId.Contains(g.Id)).ToList();

            if (estudio == null || genero.Count != item.GeneroId.Count)
            {
                return BadRequest("Estúdio ou gêneros inválidos");
            }


            var filme = new Filme();
            {
                filme.Titulo = item.Titulo;
                filme.Diretor = item.Diretor;
                filme.AnoLancamento = item.AnoLancamento;
                filme.Avaliacao = item.Avaliacao;
                filme.Estudio = estudio;
                filme.Generos = genero;
            }

            DContext.ListaFilmes.Add(filme);
            return Ok(filme);
        }


        [HttpPut("{id}")] //método Atualizar

        public IActionResult Atualizar(Guid id, [FromBody] FilmeDtos item)
        {
            var filme = DContext.ListaFilmes.FirstOrDefault( f => f.Id == id);

            if (filme == null)
            {
                return NotFound("Filme não existe");
            }

            var estudio = DContext.ListaEstudio.FirstOrDefault(e => e.Id == item.EstudioId);
            var genero = DContext.ListaGenero.Where(g => item.GeneroId.Contains(g.Id)).ToList();

            if (estudio == null || genero.Count != item.GeneroId.Count)
            {
                return BadRequest("Estúdio ou gêneros inválidos");
            }

            filme.Titulo = item.Titulo;
            filme.Estudio = estudio;
            filme.Avaliacao = item.Avaliacao;
            filme.Generos = genero;
            filme.Estudio = estudio;
            filme.AnoLancamento = item.AnoLancamento;

            return Ok("Filme atualizado!");


        }

        [HttpDelete("{id}")] //método Remover

        public IActionResult Remover(Guid id)
        {
            var filme = DContext.ListaFilmes.FirstOrDefault(g => g.Id == id);

            if (filme == null)
            {

                return NotFound("Filme não encontrado não encontrado");
            }

            DContext.ListaFilmes.Remove(filme);
            return Ok("Filme removido com sucesso!");
        }

    }
}
