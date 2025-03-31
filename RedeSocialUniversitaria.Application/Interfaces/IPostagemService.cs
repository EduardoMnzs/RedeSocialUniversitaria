public interface IPostagemService
{
    Task<PostagemDTO> CriarPostagem(Guid autorId, string conteudo);
    Task<IEnumerable<PostagemDTO>> ObterPostagensPorUsuario(Guid usuarioId);
    Task<IEnumerable<PostagemDTO>> ObterFeed(Guid usuarioId, int pagina, int tamanhoPagina);
    Task CurtirPostagem(Guid usuarioId, Guid postagemId);
    Task ComentarPostagem(Guid usuarioId, Guid postagemId, string texto);
    Task<PostagemDTO> ObterPorId(Guid id);
}