using CommonTestUtilities.Entities;
using CommonTestUtilities.Repositories;
using ConsultaAlertaDengue.Application.UseCases.GetDadosDengueUseCase;
using ConsultaAlertaDengue.Domain.Entities;
using ConsultaAlertaDengue.WebApp.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Test.Controllers;

public class IndexTest
{
    [Fact]
    public async Task Success()
    {
        var dadosDengue = ListDadosDengueBuilder.Builder();

        var useCase = CreateUseCase(dadosDengue);

        var controller = new HomeController(useCase, null);

        var result = await controller.Index();

        result.Should().BeOfType<ViewResult>();
    }

    private GetDadosDengueUseCase CreateUseCase(List<DadosDengue> dadosDengue)
    {
        var repository = new DadosDengueReadOnlyRespositoryBuilder();

        repository.GetDadosDengue(dadosDengue);

        return new GetDadosDengueUseCase(repository.Builder());
    }
}


