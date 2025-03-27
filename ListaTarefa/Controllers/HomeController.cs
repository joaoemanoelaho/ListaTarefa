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
        var tarefas = await _tarefaRepository.GetAllTarefas(); // Chama o repositório
        return View(tarefas); // Passa as tarefas para a View
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _tarefaRepository.Delete(id);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create(string descricao, DateTime dataVencimento)
    {

        System.Diagnostics.Debug.WriteLine("Ação Create chamada com: descricao = " + descricao + ", dataVencimento = " + dataVencimento);

        if (string.IsNullOrEmpty(descricao) || dataVencimento == default(DateTime))
        {
            return BadRequest("Dados inválidos.");
        }

        var data = dataVencimento.ToString("dd/MM/yyyy");
        DateTime.TryParse(data, out DateTime dataConvertida);

        var dataAtual = DateTime.Now.ToString("dd/MM/yyyy");
        DateTime.TryParse(data, out DateTime dataAtualConvertida);

        if (dataConvertida < dataAtualConvertida)
        {
            return BadRequest("Data inválida");
        }

        var tarefas = await _tarefaRepository.GetAllTarefas();

        foreach (var tarefa in tarefas)
        {
            if (descricao == tarefa.Descricao)
            {
                return BadRequest("Nome inválido");

            }
        }



        var novaTarefa = new Tarefa
        {
            Descricao = descricao,
            DataVencimento = dataVencimento,
            Concluido = false
        };

        await _tarefaRepository.AddTarefa(novaTarefa);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


}


