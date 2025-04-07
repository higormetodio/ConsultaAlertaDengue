using ConsultaAlertaDengue.Domain.Entities;

namespace ConsultaAlertaDengue.Domain.Services;

public interface IAlertaDengueService
{
    Task<(bool, string)> AtualizaDadosDengueAsync();
}
