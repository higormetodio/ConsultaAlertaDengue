using ConsultaAlertaDengue.Application.Models;
using ConsultaAlertaDengue.Domain.Repository;

namespace ConsultaAlertaDengue.Application.UseCases.GetDadosDengueBySeAno;

public class GetDadosDengueBySeAnoUseCase : IGetDadosDengueBySeAnoUseCase
{
    private readonly IDadosDengueReadOnlyRepository _dadosDengueReadOnlyRepository;

    public GetDadosDengueBySeAnoUseCase(IDadosDengueReadOnlyRepository dadosDengueReadOnlyRepository)
    {
        _dadosDengueReadOnlyRepository = dadosDengueReadOnlyRepository;
    }

    public async Task<ResultViewModel<DadosDengueViewModel>> ExecuteAsync(int semana, int ano)
    {
        var semanaEpidemiologica = Convert.ToInt32($"{ano}{semana:D2}");

        var dadosDengue = await _dadosDengueReadOnlyRepository.GetDadosDengueBySeAnoAsync(semanaEpidemiologica);

        if (dadosDengue is null)
        {
            return ResultViewModel<DadosDengueViewModel>.Error($"Dados de dengue não encontrados para a semana {semana} do ano {ano}");
        }

        var model = ResultViewModel<DadosDengueViewModel>.Success(DadosDengueViewModel.FromEntity(dadosDengue));

        return model;
    }
}
