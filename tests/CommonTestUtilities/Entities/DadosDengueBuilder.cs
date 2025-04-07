using Bogus;
using ConsultaAlertaDengue.Domain.Entities;
using ConsultaAlertaDengue.Domain.Enums;

namespace CommonTestUtilities.Entities;

public static class DadosDengueBuilder
{
    public static DadosDengue Builder()
     => new Faker<DadosDengue>()
            .CustomInstantiator(faker => new DadosDengue(
            faker.Random.Guid(),
            DateTime.Now,
            202552,
            faker.Random.Double(),
            faker.Random.Int(),
            faker.PickRandom<NivelAlerta>()));
}
