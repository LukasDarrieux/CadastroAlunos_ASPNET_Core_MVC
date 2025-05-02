using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Alunos.Models;
using Alunos.Repository;
using Alunos.Context;

namespace Alunos.Contorllers;

public class AlunoController : Controller
{
    
    private AlunoRepository _alunoRepository;

    public AlunoController(AppDbContext context)
    {
        _alunoRepository = new AlunoRepository(context);
    }

    public IActionResult Index()
    {
        var listaAlunos = _alunoRepository.GetAll();
        return View(listaAlunos);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Aluno aluno)
    {
        if(_alunoRepository.Create(aluno))
            return RedirectToAction(nameof(Index));
    
        return View();
    }

    public IActionResult Edit(int id)
    {
        var aluno = _alunoRepository.GetById(id);
        return View(aluno);
    }

    [HttpPost]
    public IActionResult Edit(Aluno aluno)
    {
        if (_alunoRepository.Edit(aluno))
            return RedirectToAction(nameof(Index));

        return View(aluno);
    }

    public IActionResult Delete(int id)
    {
        var aluno = _alunoRepository.GetById(id);
        return View(aluno);
    }

    [HttpPost]
    public IActionResult Delete(Aluno aluno)
    {
        if (_alunoRepository.Delete(aluno))
            return RedirectToAction(nameof(Index));

        return View(aluno);
    }
}