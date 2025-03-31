using RedeSocialUniversitaria.Application.DTOs;

public class PostagemDTO
{
    public Guid Id { get; set; }
    public string Conteudo { get; set; }
    public DateTime DataHora { get; set; }
    public UsuarioDTO Autor { get; set; }
    public int TotalCurtidas { get; set; }
    public int TotalComentarios { get; set; }
}