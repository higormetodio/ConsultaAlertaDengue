using ConsultaAlertaDengue.Application.UseCases.GetDadosDengueUseCase;
using ConsultaAlertaDengue.Application.UseCases.RegisterDadosDengueUseCase;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaAlertaDengue.WebApp.Controllers;

public class HomeController : Controller
{    
    private readonly IGetDadosDengueUseCase _getDadosDengueUseCase;
    private readonly IRegisterDadosDengueUseCase _registerDadosDengueUseCase;

    public HomeController(IGetDadosDengueUseCase getDadosDengueUseCase, IRegisterDadosDengueUseCase registerDadosDengueUseCase)
    {
        _getDadosDengueUseCase = getDadosDengueUseCase;
        _registerDadosDengueUseCase = registerDadosDengueUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var dadosDengue = await _getDadosDengueUseCase.ExecuteAsync();
        
        return View(dadosDengue);
    }

    [HttpPost]
    public async Task<IActionResult> GerarDadosAlertaDengue()
    {
        var result = await _registerDadosDengueUseCase.ExecuteAsync();

        return RedirectToAction("Index", result);
    }
}
