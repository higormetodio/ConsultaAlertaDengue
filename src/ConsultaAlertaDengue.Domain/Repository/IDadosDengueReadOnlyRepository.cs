using ConsultaAlertaDengue.Domain.Entities;

namespace ConsultaAlertaDengue.Domain.Repository;

public interface IDadosDengueReadOnlyRepository
{
    Task<IEnumerable<DadosDengue>> GetDadosDengueAsync();
    Task<DadosDengue> GetDadosDengueBySeAnoAsync(int semanaEpidemiologica);
}
