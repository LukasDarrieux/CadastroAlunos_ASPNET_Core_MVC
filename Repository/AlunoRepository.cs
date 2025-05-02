using System;
using Alunos.Context;
using Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace Alunos.Repository;

public class AlunoRepository
{
    private AppDbContext _context;

    public AlunoRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Aluno> GetAll()
    {
        var listaAlunos = _context.Aluno.ToList();
        return listaAlunos;
    }

    public Aluno? GetById(int idAluno)
    {
        var aluno = _context.Aluno.Find(idAluno);
        return aluno;
    }

    public bool Create(Aluno aluno)
    {
        try
        {
            if (aluno == null) return false;

            _context.Aluno.Add(aluno);
            _context.SaveChanges();

            return true;
        }
        catch
        {
            return false;
        }

    }

    public bool Edit(Aluno aluno)
    {
        try
        {
            if (aluno == null) return false;

            _context.Aluno.Entry(aluno).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool Delete(Aluno aluno)
    {
        try
        {
            if (aluno == null) return false;

            _context.Aluno.Remove(aluno);
            _context.SaveChanges();

            return true;
        }
        catch
        {
            return false;
        }
    }
}
