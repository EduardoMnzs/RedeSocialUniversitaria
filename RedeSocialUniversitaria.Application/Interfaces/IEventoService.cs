public interface IEventoService
{
    Task<EventoDTO> CriarEvento(EventoDTO eventoDTO);
    Task<IEnumerable<EventoDTO>> ObterProximosEventos();
    Task InscreverEmEvento(Guid usuarioId, Guid eventoId);
    Task<EventoDTO> ObterPorId(Guid id);
}