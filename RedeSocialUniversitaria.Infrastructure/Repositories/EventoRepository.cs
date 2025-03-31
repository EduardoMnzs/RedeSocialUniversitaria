using Microsoft.EntityFrameworkCore;
using RedeSocialUniversitaria.Infrastructure.Data;

public class EventoRepository : BaseRepository<Evento>, IEventoRepository
{
    public EventoRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Evento>> ObterProximosEventos(DateTime dataAtual)
    {
        return await _context.Eventos
            .Include(e => e.Inscricoes)
            .Where(e => e.DataHora >= dataAtual)
            .OrderBy(e => e.DataHora)
            .ToListAsync();
    }

    public async Task<bool> UsuarioEstaInscrito(Guid eventoId, Guid usuarioId)
    {
        return await _context.InscricoesEventos
            .AnyAsync(i => i.EventoId == eventoId && i.UsuarioId == usuarioId);
    }
}
