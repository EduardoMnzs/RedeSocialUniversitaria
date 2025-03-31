using RedeSocialUniversitaria.Domain.Entities;

public class Curtida : EntityBase
{
    public Guid UsuarioId { get; private set; }
    public virtual Usuario Usuario { get; private set; }
    public Guid PostagemId { get; private set; }
    public virtual Postagem Postagem { get; private set; }
    public DateTime DataHora { get; private set; }

    protected Curtida() { }

    public Curtida(Usuario usuario, Postagem postagem)
    {
        Usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
        UsuarioId = usuario.Id;
        Postagem = postagem ?? throw new ArgumentNullException(nameof(postagem));
        PostagemId = postagem.Id;
        DataHora = DateTime.UtcNow;
    }
}