using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlunosApi.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string?  Nome { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }
        [Required]
        public int Idade { get; set; }

    }
}