using ConsultaAlertaDengue.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ConsultaAlertaDengue.Infrastructure.DataAccess.Configuration;

public class DadosDengueEntityConfiguration : IEntityTypeConfiguration<DadosDengue>
{
    public void Configure(EntityTypeBuilder<DadosDengue> builder)
    {
        builder.ToTable("DadosDengue");

        builder.HasKey(alerta => alerta.Id);

        builder.Property(alerta => alerta.DataCriacao)
            .IsRequired()
            .HasColumnType("DATE");

        builder.Property(alerta => alerta.SemanaEpidemiologica)
            .IsRequired()
            .HasColumnType("INT");

        builder.Property(alerta => alerta.CasosEstimados)
            .IsRequired()
            .HasColumnType("DOUBLE");

        builder.Property(alerta => alerta.CasosNotificados)
            .IsRequired()
            .HasColumnType("INT");

        builder.Property(alerta => alerta.NivelAlerta)
            .IsRequired()
            .HasColumnType("INT");
    }
}
