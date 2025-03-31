public interface IPostagemRepository : IBaseRepository<Postagem>
{
    Task<IEnumerable<Postagem>> ObterPorUsuario(Guid usuarioId);
    Task<IEnumerable<Postagem>> ObterFeed(Guid usuarioId, int pagina, int tamanhoPagina);
}