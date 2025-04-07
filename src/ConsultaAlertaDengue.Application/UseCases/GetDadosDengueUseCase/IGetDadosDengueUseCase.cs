using ConsultaAlertaDengue.Application.Models;

namespace ConsultaAlertaDengue.Application.UseCases.GetDadosDengueUseCase;

public interface IGetDadosDengueUseCase
{
    public Task<ResultViewModel<IEnumerable<DadosDengueViewModel>>> ExecuteAsync();
}
