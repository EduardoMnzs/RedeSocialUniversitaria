using RedeSocialUniversitaria.Domain.Entities;

namespace RedeSocialUniversitaria.Domain.Interfaces;

public interface IUsuarioRepository : IBaseRepository<Usuario>
{
    Task<Usuario> ObterPorEmail(string email);
    Task<IEnumerable<Usuario>> ObterSeguidores(Guid usuarioId);
    Task<IEnumerable<Usuario>> ObterSeguindo(Guid usuarioId);
}