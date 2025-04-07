using CommonTestUtilities.Entities;
using CommonTestUtilities.Repositories;
using ConsultaAlertaDengue.Application.Models;
using ConsultaAlertaDengue.Application.UseCases.GetDadosDengueBySeAno;
using ConsultaAlertaDengue.Domain.Entities;
using FluentAssertions;

namespace Application.Test.UseCases;

public class GetDadosDengueBySeAnoUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var dadosDengue = DadosDengueBuilder.Builder();

        var viewModel = DadosDengueViewModel.FromEntity(dadosDengue);

        var useCase = CreateUseCase(dadosDengue);

        var model = await useCase.ExecuteAsync(52, 2025);

        model.Should().NotBeNull();
        model.IsSuccess.Should().BeTrue();
        model.Data.Should().BeEquivalentTo(viewModel);
    }

    [Fact]
    public async Task Erro_Dados_Dengue_Nao_Encontrado()
    {
        DadosDengue dadosDengue = DadosDengueBuilder.Builder();

        var viewModel = DadosDengueViewModel.FromEntity(dadosDengue);

        var useCase = CreateUseCase(dadosDengue);

        var model = await useCase.ExecuteAsync(12, 2024);

        model.Should().NotBeNull();
        model.IsSuccess.Should().BeFalse();
        model.Message.Should().Be("Dados de dengue não encontrados para a semana 12 do ano 2024");
    }

    private GetDadosDengueBySeAnoUseCase CreateUseCase(DadosDengue dadosDengue)
    {
        var repository = new DadosDengueReadOnlyRespositoryBuilder();

        repository.GetDadosDengueBySeAno(dadosDengue);

        return new GetDadosDengueBySeAnoUseCase(repository.Builder());
    }
}
