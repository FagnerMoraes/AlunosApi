using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlunosApi.Models;

namespace AlunosApi.Service
{
    public class AlunoService : IAlunoService
    {
        public Task AtualizarAluno(Aluno aluno)
        {
            throw new NotImplementedException();
        }

        public Task CriarAluno(Aluno aluno)
        {
            throw new NotImplementedException();
        }

        public Task DeletarAluno(Aluno aluno)
        {
            throw new NotImplementedException();
        }

        public Task<Aluno> ObterAlunoPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Aluno>> ObterAlunosPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Aluno>> ObterTodosAlunos()
        {
            throw new NotImplementedException();
        }
    }
}