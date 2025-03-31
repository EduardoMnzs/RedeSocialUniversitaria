using Microsoft.EntityFrameworkCore;
using RedeSocialUniversitaria.Domain.Entities;
using RedeSocialUniversitaria.Domain.Interfaces;
using RedeSocialUniversitaria.Infrastructure.Data;

namespace RedeSocialUniversitaria.Infrastructure.Repositories;

public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Usuario> ObterPorEmail(string email)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<IEnumerable<Usuario>> ObterSeguidores(Guid usuarioId)
    {
        return await _context.Usuarios
            .Where(u => u.Seguindo.Any(s => s.Id == usuarioId))
            .ToListAsync();
    }

    public async Task<IEnumerable<Usuario>> ObterSeguindo(Guid usuarioId)
    {
        var usuario = await _context.Usuarios
            .Include(u => u.Seguindo)
            .FirstOrDefaultAsync(u => u.Id == usuarioId);

        return usuario?.Seguindo ?? new List<Usuario>();
    }
}