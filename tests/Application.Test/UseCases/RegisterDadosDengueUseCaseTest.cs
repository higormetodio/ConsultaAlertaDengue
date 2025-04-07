using CommonTestUtilities.Services;
using ConsultaAlertaDengue.Application.UseCases.RegisterDadosDengueUseCase;
using ConsultaAlertaDengue.Domain.Services;
using FluentAssertions;

namespace Application.Test.UseCases;

public class RegisterDadosDengueUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var useCase = CreateUseCase(true, "Dados atualizados com sucesso.");

        var model = await useCase.ExecuteAsync();

        model.Should().NotBeNull();
        model.IsSuccess.Should().BeTrue();
        model.Data.Should().Be("Dados atualizados com sucesso.");

    }

    [Fact]
    public async Task Error_Retorno_Infrastructure()
    {
        var useCase = CreateUseCase(false, "Erro ao acessar a API, pois apresentou um erro com StatusCode 500");
        
        var model = await useCase.ExecuteAsync();
        
        model.Should().NotBeNull();
        model.IsSuccess.Should().BeFalse();
        model.Message.Should().Be("Erro ao acessar a API, pois apresentou um erro com StatusCode 500");
    }

    public static RegisterDadosDengueUseCase CreateUseCase(bool success, string message)
    {
        var service = new AlertaDengueServiceBuilder();
        
        service.AtualizaDadosDengue(success, message);

        return new RegisterDadosDengueUseCase(service.Builder());
    }
}
