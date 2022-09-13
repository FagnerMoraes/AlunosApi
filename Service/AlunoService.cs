using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlunosApi.Context;
using AlunosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunosApi.Service
{
    public class AlunoService : IAlunoService
    {
        private readonly AppDbContext _context;

        public AlunoService(AppDbContext contex)
        {
            _context = contex;
        }

        public async Task<Aluno> ObterAlunoPorId(int Id)
        {
            var aluno = await _context.Alunos.FindAsync(Id);
            return aluno;   
            
        }

        public async Task<IEnumerable<Aluno>> ObterAlunosPorNome(string nome)
        {
            IEnumerable<Aluno> alunos;
            if(!string.IsNullOrWhiteSpace(nome)){
                alunos =  await _context.Alunos
                .AsNoTracking()
                .Where(n => n.Nome.Contains(nome))
                .ToListAsync();   
            }
            else{
                alunos = await ObterTodosAlunos();
            }

            return alunos;
            
        }

        public async Task<IEnumerable<Aluno>> ObterTodosAlunos()
        {
            try{
            return await _context.Alunos
                .AsNoTracking()
                .ToListAsync();
            }
            catch{
                throw;
            }

        }
        public async Task AtualizarAluno(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task CriarAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAluno(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
        }

        

        
    }
}