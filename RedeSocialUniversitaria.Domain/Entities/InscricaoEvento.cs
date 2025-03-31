using RedeSocialUniversitaria.Domain.Entities;

public class InscricaoEvento : EntityBase
{
    public Guid UsuarioId { get; private set; }
    public virtual Usuario Usuario { get; private set; }
    public Guid EventoId { get; private set; }
    public virtual Evento Evento { get; private set; }
    public DateTime DataInscricao { get; private set; }

    protected InscricaoEvento() { }

    public InscricaoEvento(Usuario usuario, Evento evento)
    {
        Usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
        UsuarioId = usuario.Id;
        Evento = evento ?? throw new ArgumentNullException(nameof(evento));
        EventoId = evento.Id;
        DataInscricao = DateTime.UtcNow;
    }
}