using ConsultaAlertaDengue.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ConsultaAlertaDengue.Infrastructure.DataAccess;

public class ConsultaAlertaDengueDbContext : DbContext
{
    public ConsultaAlertaDengueDbContext(DbContextOptions<ConsultaAlertaDengueDbContext> options)
        : base(options)
    {
    }

    public DbSet<DadosDengue> DadosDengue { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConsultaAlertaDengueDbContext).Assembly);
    }
}
