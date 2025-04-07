using System.Text.Json.Serialization;

namespace ConsultaAlertaDengue.Domain.Entities;

public abstract class EntityBase
{
    protected EntityBase(Guid id, DateTime dataCriacao)
    {
        Id = id;
        DataCriacao = DateTime.UtcNow;
    }

    [JsonIgnore]
    public Guid Id { get; private set; }
    [JsonIgnore]
    public DateTime DataCriacao { get; set; }
}
