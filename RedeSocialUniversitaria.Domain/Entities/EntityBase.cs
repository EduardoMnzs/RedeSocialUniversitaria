public abstract class EntityBase
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public DateTime DataCriacao { get; protected set; } = DateTime.UtcNow;
    public DateTime? DataAtualizacao { get; protected set; }
}