using ConsultaAlertaDengue.Application.UseCases.GetDadosDengueBySeAno;
using ConsultaAlertaDengue.Application.UseCases.GetDadosDengueUseCase;
using ConsultaAlertaDengue.Application.UseCases.RegisterDadosDengueUseCase;
using Microsoft.Extensions.DependencyInjection;

namespace ConsultaAlertaDengue.Application;

public static class DependencyInjectionException
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IGetDadosDengueUseCase, GetDadosDengueUseCase>();
        services.AddScoped<IGetDadosDengueBySeAnoUseCase, GetDadosDengueBySeAnoUseCase>();
        services.AddScoped<IRegisterDadosDengueUseCase,  RegisterDadosDengueUseCase>();
    }
}
