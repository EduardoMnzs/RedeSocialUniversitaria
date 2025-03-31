using Microsoft.EntityFrameworkCore;
using RedeSocialUniversitaria.Infrastructure.Data;

public class PostagemRepository : BaseRepository<Postagem>, IPostagemRepository
{
    public PostagemRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Postagem>> ObterPorUsuario(Guid usuarioId)
    {
        return await _context.Postagens
            .Include(p => p.Autor)
            .Include(p => p.Curtidas)
            .Include(p => p.Comentarios)
            .Where(p => p.AutorId == usuarioId)
            .OrderByDescending(p => p.DataHora)
            .ToListAsync();
    }

    public async Task<IEnumerable<Postagem>> ObterFeed(Guid usuarioId, int pagina, int tamanhoPagina)
    {
        var usuario = await _context.Usuarios
            .Include(u => u.Seguindo)
            .FirstOrDefaultAsync(u => u.Id == usuarioId);

        if (usuario == null)
            return new List<Postagem>();

        var idsUsuariosSeguidos = usuario.Seguindo.Select(u => u.Id).ToList();
        idsUsuariosSeguidos.Add(usuarioId); // Inclui as próprias postagens no feed

        return await _context.Postagens
            .Include(p => p.Autor)
            .Include(p => p.Curtidas)
            .Include(p => p.Comentarios)
            .Where(p => idsUsuariosSeguidos.Contains(p.AutorId))
            .OrderByDescending(p => p.DataHora)
            .Skip((pagina - 1) * tamanhoPagina)
            .Take(tamanhoPagina)
            .ToListAsync();
    }
}
