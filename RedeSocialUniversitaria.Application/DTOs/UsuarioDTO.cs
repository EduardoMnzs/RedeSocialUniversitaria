namespace RedeSocialUniversitaria.Application.DTOs;

public class UsuarioDTO
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Curso { get; set; }
    public int TotalSeguidores { get; set; }
    public int TotalSeguindo { get; set; }
}