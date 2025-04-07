using ConsultaAlertaDengue.Application.Models;
using ConsultaAlertaDengue.Application.UseCases.GetDadosDengueBySeAno;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaAlertaDengue.API.Controllers;

[Route("[controller]")]
[ApiController]
public class DadosDengueController : ControllerBase
{
    private readonly IGetDadosDengueBySeAnoUseCase _getDadosDengueBySeAnoUseCase;

    public DadosDengueController(IGetDadosDengueBySeAnoUseCase getDadosDengueBySeAnoUseCase)
    {
        _getDadosDengueBySeAnoUseCase = getDadosDengueBySeAnoUseCase;
    }

    [HttpGet()]
    [ProducesResponseType(typeof(ResultViewModel<DadosDengueViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResultViewModel<DadosDengueViewModel>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDadosDengueBySeAno(
        [FromQuery] int semana,
        [FromQuery] int ano)
    {
        var result = await _getDadosDengueBySeAnoUseCase.ExecuteAsync(semana, ano);

        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }

        return NotFound(result);
    }
}
