using CommonTestUtilities.Services;
using ConsultaAlertaDengue.Application.Models;
using ConsultaAlertaDengue.Application.UseCases.RegisterDadosDengueUseCase;
using ConsultaAlertaDengue.WebApp.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Test.Controllers;

public class GerarDadosDengueTest
{
    [Fact]
    public async Task Success()
    {
        var (success, message) = (true, "Dados atualizados com sucesso.");

        var model = new ResultViewModel<string>(message);
        
        var useCase = CreateUseCase(success, message);

        var controller = new HomeController(null, useCase);

        var result = await controller.GerarDadosAlertaDengue();

        result.Should().BeOfType<ViewResult>().Which.ViewName.Should().Be("Index");
    }

    private RegisterDadosDengueUseCase CreateUseCase(bool success, string message)
    {
        var service = new AlertaDengueServiceBuilder();

        service.AtualizaDadosDengue(success, message);

        return new RegisterDadosDengueUseCase(service.Builder());
    }
}
