namespace RedeSocialUniversitaria.Domain.Entities;

public class Usuario : EntityBase
{
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Curso { get; private set; }
    public virtual ICollection<Usuario> Seguindo { get; private set; } = new List<Usuario>();
    public virtual ICollection<Usuario> Seguidores { get; private set; } = new List<Usuario>();
    public virtual ICollection<Postagem> Postagens { get; private set; } = new List<Postagem>();
    public virtual ICollection<Curtida> Curtidas { get; private set; } = new List<Curtida>();
    public virtual ICollection<Comentario> Comentarios { get; private set; } = new List<Comentario>();
    public virtual ICollection<InscricaoEvento> InscricoesEventos { get; private set; } = new List<InscricaoEvento>();

    protected Usuario() { } // Para o EF

    public Usuario(string nome, string email, string curso)
    {
        Nome = nome;
        Email = email;
        Curso = curso;
    }

    public void Seguir(Usuario usuarioASeguir)
    {
        if (usuarioASeguir == null)
            throw new ArgumentNullException(nameof(usuarioASeguir));

        if (Seguindo.Any(u => u.Id == usuarioASeguir.Id))
            return;

        Seguindo.Add(usuarioASeguir);
        usuarioASeguir.Seguidores.Add(this);
    }

    public void DeixarDeSeguir(Usuario usuario)
    {
        if (usuario == null)
            throw new ArgumentNullException(nameof(usuario));

        var usuarioParaRemover = Seguindo.FirstOrDefault(u => u.Id == usuario.Id);
        if (usuarioParaRemover != null)
        {
            Seguindo.Remove(usuarioParaRemover);
            usuarioParaRemover.Seguidores.Remove(this);
        }
    }
}