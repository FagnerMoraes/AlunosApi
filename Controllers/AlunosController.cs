using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlunosApi.Service;
using AlunosApi.Models;

namespace AlunosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Produces("application/json")]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos() {
            try {
                var alunos = await _alunoService.ObterTodosAlunos();
                return Ok(alunos);
            }
            catch {
                //return BadRequest();
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Alunos");
            }
        }

        [HttpGet("AlunosPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunosByName([FromQuery] string nome)
        {
            try
            {
                var alunos = await _alunoService.ObterAlunosPorNome(nome);

                if (alunos.Count() == 0)
                {
                    return NotFound($"Não existem alunos com o critério {nome}");
                }

                return Ok(alunos);
            }
            catch
            {
                return BadRequest("Request Invalido");
                //return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Alunos");
            }
        }
        
        [HttpGet("{id:int}", Name= "GetAluno")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            try
            {
                var aluno = await _alunoService.ObterAlunoPorId(id);
                if (aluno == null)
                    return NotFound($"Não existe aluno com id={id}");

                return Ok(aluno);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }


        [HttpPost]
        public  async Task<ActionResult> Create(Aluno aluno)
        {
            try
            {
                await _alunoService.CriarAluno(aluno);
                return CreatedAtRoute(nameof(GetAluno),new { id = aluno.Id }, aluno);
            }
            catch
            {
                return BadRequest("Request invalido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] Aluno aluno)
        {
            try
            {
                if(aluno.Id == id)
                {
                    await _alunoService.AtualizarAluno(aluno);
                    return Ok($"Aluno com id={id} foi atualizado com sucesso");

                }
                else
                {
                    return BadRequest("Dados inconsistentes");
                }
                
            }
            catch
            {
                return BadRequest("Request invalido");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                var aluno = await _alunoService.ObterAlunoPorId(id);
                if(aluno != null)
                {
                    await _alunoService.DeletarAluno(aluno);
                    return Ok($"Aluno de id={id} foi excluido com sucesso");
                }
                else
                {
                    return NotFound("Aluno não encontrado");
                }
               
            }
            catch
            {
                return BadRequest("Request invalido");
            }
        }

    }
}