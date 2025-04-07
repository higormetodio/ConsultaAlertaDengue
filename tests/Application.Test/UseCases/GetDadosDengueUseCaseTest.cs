using CommonTestUtilities.Entities;
using CommonTestUtilities.Repositories;
using ConsultaAlertaDengue.Application.Models;
using ConsultaAlertaDengue.Application.UseCases.GetDadosDengueUseCase;
using ConsultaAlertaDengue.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Test.UseCases;

public class GetDadosDengueUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var dadosDengue = ListDadosDengueBuilder.Builder();

        var viewModel = dadosDengue.Select(DadosDengueViewModel.FromEntity).ToList();

        var useCase = CreateUseCase(dadosDengue);

        var model = await useCase.ExecuteAsync();

        model.Should().NotBeNull();
        model.IsSuccess.Should().BeTrue();
        model.Data.Should().BeEquivalentTo(viewModel);
    }

    [Fact]
    public async Task Error_Nao_Existe_Dados_Banco_Dados()
    {
        var dadosDengue = new List<DadosDengue>();

        var viewModel = dadosDengue.Select(DadosDengueViewModel.FromEntity).ToList();

        var useCase = CreateUseCase(dadosDengue);

        var model = await useCase.ExecuteAsync();

        model.Should().NotBeNull();
        model.IsSuccess.Should().BeFalse();
        model.Message.Should().Be("Ainda não temos nenhum dado em banco. Atualize os daos!");

    }

    private GetDadosDengueUseCase CreateUseCase(List<DadosDengue> dadosDengue)
    {
        var repository = new DadosDengueReadOnlyRespositoryBuilder();

        repository.GetDadosDengue(dadosDengue);

        return new GetDadosDengueUseCase(repository.Builder());
    }
}
