using ConsultaAlertaDengue.Application.Models;

namespace ConsultaAlertaDengue.Application.UseCases.GetDadosDengueBySeAno;

public interface IGetDadosDengueBySeAnoUseCase
{
    Task<ResultViewModel<DadosDengueViewModel>> ExecuteAsync(int semana, int ano);
}
