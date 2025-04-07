using ConsultaAlertaDengue.Application.Models;
using ConsultaAlertaDengue.Domain.Repository;
using Microsoft.IdentityModel.Tokens;

namespace ConsultaAlertaDengue.Application.UseCases.GetDadosDengueUseCase;

public class GetDadosDengueUseCase : IGetDadosDengueUseCase
{
    private readonly IDadosDengueReadOnlyRepository _dadosDengueReadOnlyRepository;

    public GetDadosDengueUseCase(IDadosDengueReadOnlyRepository dadosDengueReadOnlyRepository)
    {
        _dadosDengueReadOnlyRepository = dadosDengueReadOnlyRepository;
    }

    public async Task<ResultViewModel<IEnumerable<DadosDengueViewModel>>> ExecuteAsync()
    {
        var dadosDengue = await _dadosDengueReadOnlyRepository.GetDadosDengueAsync();

        if (dadosDengue.IsNullOrEmpty())
        {
            return ResultViewModel<IEnumerable<DadosDengueViewModel>>.Error("Ainda não temos nenhum dado em banco. Atualize os daos!");
        }

        var model = ResultViewModel<IEnumerable<DadosDengueViewModel>>.Success(dadosDengue.Select(DadosDengueViewModel.FromEntity));

        return model;
    }
}
