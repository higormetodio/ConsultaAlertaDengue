using ConsultaAlertaDengue.Application.Models;
using ConsultaAlertaDengue.Domain.Entities;
using ConsultaAlertaDengue.Domain.Services;
using NSubstitute;

namespace CommonTestUtilities.Services;

public class AlertaDengueServiceBuilder
{
    private readonly IAlertaDengueService _service = Substitute.For<IAlertaDengueService>();

    public void AtualizaDadosDengue(bool success, string message)
    {
        _service.AtualizaDadosDengueAsync().Returns(Task.FromResult((success, message)));
    }

    public IAlertaDengueService Builder() => _service;
}
