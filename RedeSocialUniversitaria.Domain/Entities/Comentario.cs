using RedeSocialUniversitaria.Domain.Entities;

public class Comentario : EntityBase
{
    public string Texto { get; private set; }
    public DateTime DataHora { get; private set; }
    public Guid AutorId { get; private set; }
    public virtual Usuario Autor { get; private set; }
    public Guid PostagemId { get; private set; }
    public virtual Postagem Postagem { get; private set; }

    protected Comentario() { }

    public Comentario(string texto, Usuario autor, Postagem postagem)
    {
        Texto = texto;
        Autor = autor ?? throw new ArgumentNullException(nameof(autor));
        AutorId = autor.Id;
        Postagem = postagem ?? throw new ArgumentNullException(nameof(postagem));
        PostagemId = postagem.Id;
        DataHora = DateTime.UtcNow;
    }
}