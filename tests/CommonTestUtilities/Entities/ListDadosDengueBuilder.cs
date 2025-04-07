using Bogus;
using ConsultaAlertaDengue.Domain.Entities;
using ConsultaAlertaDengue.Domain.Enums;

namespace CommonTestUtilities.Entities;

public class ListDadosDengueBuilder
{
    public static List<DadosDengue> Builder()
    {
        var dadosFakers = new Faker<DadosDengue>()
            .CustomInstantiator(faker => new DadosDengue(faker.Random.Guid(),
            DateTime.Now,
            faker.Random.Int(min: 202501, max: 202552),
            faker.Random.Double(),
            faker.Random.Int(),
            faker.PickRandom<NivelAlerta>()));

        var listaDadosDengue = dadosFakers.Generate(20);

        return listaDadosDengue;
    }
}
