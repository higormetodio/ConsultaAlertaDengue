using ConsultaAlertaDengue.Domain.Entities;
using ConsultaAlertaDengue.Domain.Repository;
using NSubstitute;

namespace CommonTestUtilities.Repositories;

public class DadosDengueReadOnlyRespositoryBuilder
{
    private readonly IDadosDengueReadOnlyRepository _repository = Substitute.For<IDadosDengueReadOnlyRepository>();

    public void GetDadosDengueBySeAno(DadosDengue dadosDengue)
    {
        _repository.GetDadosDengueBySeAnoAsync(dadosDengue.SemanaEpidemiologica).Returns(Task.FromResult(dadosDengue));
    }

    public void GetDadosDengue(IEnumerable<DadosDengue> listDadosDengue)
    {
        _repository.GetDadosDengueAsync().Returns(Task.FromResult(listDadosDengue));
    }

    public IDadosDengueReadOnlyRepository Builder() => _repository;
}
