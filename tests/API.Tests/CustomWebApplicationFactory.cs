using CommonTestUtilities.Entities;
using ConsultaAlertaDengue.Domain.Entities;
using ConsultaAlertaDengue.Domain.ValueObjects;
using ConsultaAlertaDengue.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace WebApp.Test;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    private DadosDengue? _dadosDengue = default;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test")
            .ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ConsultaAlertaDengueDbContext>));

                if (descriptor is not null)
                {
                    services.Remove(descriptor);
                }

                services.AddHttpClient();

                var provider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                services.AddDbContext<ConsultaAlertaDengueDbContext>(options =>
                {
                    options.UseInMemoryDatabase("ConsultaAlertaDengueDbInMemoryTest");
                    options.UseInternalServiceProvider(provider);
                });

                using var scope = services.BuildServiceProvider().CreateScope();

                var context = scope.ServiceProvider.GetRequiredService<ConsultaAlertaDengueDbContext>();

                context.Database.EnsureDeleted();

                StartDatabase(context);
            });
    }

    public DadosDengue GetDadosDengue() => _dadosDengue!;

    private void StartDatabase(ConsultaAlertaDengueDbContext context)
    {
        _dadosDengue = DadosDengueBuilder.Builder();

        context.DadosDengue.Add(_dadosDengue);

        var teste = context.SaveChanges();
    }
}
