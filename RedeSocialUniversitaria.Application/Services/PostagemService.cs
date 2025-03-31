using AutoMapper;
using RedeSocialUniversitaria.Domain.Interfaces;

public class PostagemService : IPostagemService
{
    private readonly IPostagemRepository _postagemRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;

    public PostagemService(IPostagemRepository postagemRepository,
                         IUsuarioRepository usuarioRepository,
                         IMapper mapper)
    {
        _postagemRepository = postagemRepository;
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
    }

    public async Task<PostagemDTO> ObterPorId(Guid id)
    {
        var postagem = await _postagemRepository.ObterPorId(id);
        if (postagem == null)
            return null;

        var postagemDTO = _mapper.Map<PostagemDTO>(postagem);
        return postagemDTO;
    }

    public async Task<PostagemDTO> CriarPostagem(Guid autorId, string conteudo)
    {
        var autor = await _usuarioRepository.ObterPorId(autorId);
        if (autor == null)
            throw new ApplicationException("Usuário não encontrado");

        var postagem = new Postagem(conteudo, autor);
        await _postagemRepository.Adicionar(postagem);
        return _mapper.Map<PostagemDTO>(postagem);
    }

    public async Task<IEnumerable<PostagemDTO>> ObterPostagensPorUsuario(Guid usuarioId)
    {
        var postagens = await _postagemRepository.ObterPorUsuario(usuarioId);
        return _mapper.Map<IEnumerable<PostagemDTO>>(postagens);
    }

    public async Task<IEnumerable<PostagemDTO>> ObterFeed(Guid usuarioId, int pagina, int tamanhoPagina)
    {
        var postagens = await _postagemRepository.ObterFeed(usuarioId, pagina, tamanhoPagina);
        return _mapper.Map<IEnumerable<PostagemDTO>>(postagens);
    }

    public async Task CurtirPostagem(Guid usuarioId, Guid postagemId)
    {
        var usuario = await _usuarioRepository.ObterPorId(usuarioId);
        var postagem = await _postagemRepository.ObterPorId(postagemId);

        if (usuario == null || postagem == null)
            throw new ApplicationException("Usuário ou postagem não encontrados");

        if (postagem.Curtidas.Any(c => c.UsuarioId == usuarioId))
            return; // Já curtiu

        var curtida = new Curtida(usuario, postagem);
        postagem.Curtidas.Add(curtida);
        await _postagemRepository.Atualizar(postagem);
    }

    public async Task ComentarPostagem(Guid usuarioId, Guid postagemId, string texto)
    {
        var usuario = await _usuarioRepository.ObterPorId(usuarioId);
        var postagem = await _postagemRepository.ObterPorId(postagemId);

        if (usuario == null || postagem == null)
            throw new ApplicationException("Usuário ou postagem não encontrados");

        var comentario = new Comentario(texto, usuario, postagem);
        postagem.AdicionarComentario(comentario);
        await _postagemRepository.Atualizar(postagem);
    }
}