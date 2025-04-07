using ConsultaAlertaDengue.Domain.Entities;
using ConsultaAlertaDengue.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace ConsultaAlertaDengue.Infrastructure.DataAccess.Repository;

public class DadosDengueRepository : IDadosDengueReadOnlyRepository
{
    private readonly ConsultaAlertaDengueDbContext _context;

    public DadosDengueRepository(ConsultaAlertaDengueDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DadosDengue>> GetDadosDengueAsync()
        => await _context
        .DadosDengue
        .AsNoTracking()
        .ToListAsync();

    public async Task<DadosDengue> GetDadosDengueBySeAnoAsync(int semanaEpidemiologica)
        => await _context
        .DadosDengue
        .AsNoTracking()
        .SingleOrDefaultAsync(dados => dados.SemanaEpidemiologica.Equals(semanaEpidemiologica));


}
