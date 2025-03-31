public interface IEventoRepository : IBaseRepository<Evento>
{
    Task<IEnumerable<Evento>> ObterProximosEventos(DateTime dataAtual);
    Task<bool> UsuarioEstaInscrito(Guid eventoId, Guid usuarioId);
}