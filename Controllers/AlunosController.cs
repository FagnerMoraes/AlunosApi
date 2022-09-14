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
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos(){
           try{
                var alunos = await _alunoService.ObterTodosAlunos();
                return Ok(alunos);
           }
           catch{
                //return BadRequest();
                return StatusCode(StatusCodes.Status500InternalServerError,"Erro ao obter Alunos");
           } 
        }


    }
}