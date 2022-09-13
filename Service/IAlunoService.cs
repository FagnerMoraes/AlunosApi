using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlunosApi.Models;

namespace AlunosApi.Service
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> ObterTodosAlunos();
        Task<Aluno> ObterAlunoPorId(int Id);

        Task<IEnumerable<Aluno>> ObterAlunosPorNome(string nome);
        Task CriarAluno(Aluno aluno);

        Task AtualizarAluno(Aluno aluno);

        Task DeletarAluno(Aluno aluno);
    }
}