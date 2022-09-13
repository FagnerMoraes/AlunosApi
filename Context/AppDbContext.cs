using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlunosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunosApi.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().HasData(
                new Aluno{
                    Id = 1,
                    Nome = "Fabio Junior",
                    Email = "fabiojunior@gmail.com",
                    Idade = 30
                },
                new Aluno{
                    Id = 2,
                    Nome = "Maria Antonieta",
                    Email = "antonieta.maria@gmail.com",
                    Idade = 34
                },
                new Aluno{
                    Id = 3,
                    Nome = "Jose Ricardo",
                    Email = "Ricardin323@gmail.com",
                    Idade = 25
                }
            );
        }

        public DbSet<Aluno> Alunos{ get; set; }
        
    }

    

    
}