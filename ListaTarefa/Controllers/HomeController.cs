using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ListaTarefa.Models;
using ListaTarefa.Repository;

namespace ListaTarefa.Controllers;

public class HomeController : Controller
{

    private readonly TarefaRepository _tarefaRepository;
 
    public HomeController(TarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }

    public IActionResult Index()
    {
        return View();
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


