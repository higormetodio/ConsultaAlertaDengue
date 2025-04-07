using Microsoft.Extensions.Configuration;

namespace ConsultaAlertaDengue.Infrastructure.Extensions;

public static class ConfigurationExtension
{
    public static string ConnectionStringMySql(this IConfiguration configuration)
    {
        return configuration.GetConnectionString("ConsultaAlertaDengueDb")!;
    }

    public static bool IsUnitTestEnviroment(this IConfiguration configuration)
    {
        return configuration.GetValue<bool>("InMemoryTeste");
    }
}
