using RedeSocialUniversitaria.Application.DTOs;

namespace RedeSocialUniversitaria.Application.Interfaces;

public interface IUsuarioService
{
    Task<UsuarioDTO> ObterPorId(Guid id);
    Task<IEnumerable<UsuarioDTO>> ObterTodos();
    Task<UsuarioDTO> Adicionar(UsuarioDTO usuarioDTO);
    Task Seguir(Guid seguidorId, Guid seguidoId);
    Task DeixarDeSeguir(Guid seguidorId, Guid seguidoId);
}