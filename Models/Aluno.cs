using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alunos.Models;

[Table("Aluno")]
public class Aluno
{
    [Key]
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? NomeMae {get; set; }
    public string? NomePai {get; set; }
    public DateTime DataNascimento { get; set; }
}
