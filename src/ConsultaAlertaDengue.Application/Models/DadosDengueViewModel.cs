using ConsultaAlertaDengue.Domain.Enums;

namespace ConsultaAlertaDengue.Application.Models;

public class DadosDengueViewModel
{
    public DadosDengueViewModel(int semanaEpidemiologica, double casosEstimados, long casosNotificados, NivelAlerta nivelAlerta)
    {
        SemanaEpidemiologica = semanaEpidemiologica;
        CasosEstimados = casosEstimados;
        CasosNotificados = casosNotificados;
        NivelAlerta = nivelAlerta;
    }

    public int SemanaEpidemiologica { get; private set; }
    public double CasosEstimados { get; set; }
    public long CasosNotificados { get; private set; }
    public NivelAlerta NivelAlerta { get; private set; }

    public static DadosDengueViewModel FromEntity(Domain.Entities.DadosDengue entity)
        => new DadosDengueViewModel(
            entity.SemanaEpidemiologica!,
            entity.CasosEstimados,
            entity.CasosNotificados,
            entity.NivelAlerta
        );
}
