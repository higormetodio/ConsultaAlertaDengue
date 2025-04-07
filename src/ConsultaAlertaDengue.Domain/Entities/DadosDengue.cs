using ConsultaAlertaDengue.Domain.Enums;
using System.Text.Json.Serialization;

namespace ConsultaAlertaDengue.Domain.Entities;

public class DadosDengue : EntityBase
{
    public DadosDengue(Guid id,
        DateTime dataCriacao,
        int semanaEpidemiologica,
        double casosEstimados,
        int casosNotificados,
        NivelAlerta nivelAlerta) : base(id, dataCriacao)
    {
        SemanaEpidemiologica = semanaEpidemiologica;
        CasosEstimados = casosEstimados;
        CasosNotificados = casosNotificados;
        NivelAlerta = nivelAlerta;
    }

    [JsonPropertyName("SE")]
    public int SemanaEpidemiologica { get; private set; }
    [JsonPropertyName("casos_est")]
    public double CasosEstimados { get; set; }
    [JsonPropertyName("casos")]
    public int CasosNotificados { get; private set; }
    [JsonPropertyName("nivel")]
    public NivelAlerta NivelAlerta { get; private set; }
}
