using RedeSocialUniversitaria.Domain.Entities;

public class Postagem : EntityBase
{
    public string Conteudo { get; private set; }
    public DateTime DataHora { get; private set; }
    public Guid AutorId { get; private set; }
    public virtual Usuario Autor { get; private set; }
    public virtual ICollection<Curtida> Curtidas { get; private set; } = new List<Curtida>();
    public virtual ICollection<Comentario> Comentarios { get; private set; } = new List<Comentario>();

    protected Postagem() { }

    public Postagem(string conteudo, Usuario autor)
    {
        Conteudo = conteudo;
        Autor = autor ?? throw new ArgumentNullException(nameof(autor));
        AutorId = autor.Id;
        DataHora = DateTime.UtcNow;
    }

    public void AdicionarComentario(Comentario comentario)
    {
        if (comentario == null)
            throw new ArgumentNullException(nameof(comentario));

        Comentarios.Add(comentario);
    }
}