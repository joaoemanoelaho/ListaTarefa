using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ListaTarefa.Models;
using ListaTarefa.Repository;
using System.Globalization;

namespace ListaTarefa.Controllers;

public class HomeController : Controller
{

    private readonly TarefaRepository _tarefaRepository;

    public HomeController(TarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }

    public async Task<IActionResult> Index()
    {
        var tarefas = await _tarefaRepository.GetAllTarefas();
        return View(tarefas);
    }

    [HttpPost]
    public async Task<IActionResult> AlternarConcluido(int id)
    {
        await _tarefaRepository.AlternarConcluido(id);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AlternarStatus(int id)
    {
        await _tarefaRepository.AlternarStatus(id);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Deletar(int id)
    {
        await _tarefaRepository.Deletar(id);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Atualizar(int id, string descricao, DateTime dataVencimento, bool status)
    {
        var tarefas = await _tarefaRepository.GetAllTarefas();

        foreach (var tarefa in tarefas)
        {
            if (descricao == tarefa.Descricao && tarefa.Concluido == false)
            {
                if (id != tarefa.Id)
                {
                    return BadRequest("Dados inválidos.");
                }
            }
        }

        await _tarefaRepository.Atualizar(id, descricao, dataVencimento, status);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create(string descricao, DateTime dataVencimento, bool status)
    {

        var tarefas = await _tarefaRepository.GetAllTarefas();

        foreach (var tarefa in tarefas)
        {
            if (descricao == tarefa.Descricao && tarefa.Concluido == false)
            {
                return BadRequest("Dados inválidos.");
            }
        }

        var novaTarefa = new Tarefa
        {
            Descricao = descricao,
            DataVencimento = dataVencimento,
            Concluido = false,
            Status = status
        };

        await _tarefaRepository.AddTarefa(novaTarefa);

        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


}


