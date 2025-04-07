using ConsultaAlertaDengue.Infrastructure.Extensions;
using ConsultaAlertaDengue.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using ConsultaAlertaDengue.Infrastructure.DataAccess.Repository;
using ConsultaAlertaDengue.Domain.Repository;
using ConsultaAlertaDengue.Domain.Services;
using ConsultaAlertaDengue.Infrastructure.Services;

namespace ConsultaAlertaDengue.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContextMySql(services, configuration);
        AddHttpClient(services);
        AddRepository(services);
        AddServices(services);

        if (configuration.IsUnitTestEnviroment())
        {
            return;
        }
    }

    private static void AddDbContextMySql(IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.ConnectionStringMySql();

        services.AddDbContext<ConsultaAlertaDengueDbContext>(options =>
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 3, 0))));
    }

    private static void AddHttpClient(IServiceCollection services)
    {
        services.AddHttpClient("AlertaDengueApi", client =>
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });
    }

    private static void AddRepository(IServiceCollection services)
    {
        services.AddScoped<IDadosDengueReadOnlyRepository, DadosDengueRepository>();
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IAlertaDengueService, AlertaDengueService>();
    }
}
