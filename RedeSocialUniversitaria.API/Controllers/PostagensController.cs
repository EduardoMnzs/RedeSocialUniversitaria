using Microsoft.AspNetCore.Mvc;
using RedeSocialUniversitaria.Application.DTOs;

[ApiController]
[Route("api/[controller]")]
public class PostagensController : ControllerBase
{
    private readonly IPostagemService _postagemService;

    public PostagensController(IPostagemService postagemService)
    {
        _postagemService = postagemService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PostagemDTO>> ObterPorId(Guid id)
    {
        var postagem = await _postagemService.ObterPorId(id);
        if (postagem == null)
            return NotFound();

        return Ok(postagem);
    }

    [HttpPost]
    public async Task<ActionResult<PostagemDTO>> CriarPostagem([FromBody] CriarPostagemDTO dto)
    {
        var postagem = await _postagemService.CriarPostagem(dto.AutorId, dto.Conteudo);
        return CreatedAtAction(nameof(ObterPorId), new { id = postagem.Id }, postagem);
    }

    [HttpGet("usuario/{usuarioId}")]
    public async Task<ActionResult<IEnumerable<PostagemDTO>>> ObterPorUsuario(Guid usuarioId)
    {
        var postagens = await _postagemService.ObterPostagensPorUsuario(usuarioId);
        return Ok(postagens);
    }

    [HttpGet("feed/{usuarioId}")]
    public async Task<ActionResult<IEnumerable<PostagemDTO>>> ObterFeed(
        Guid usuarioId, [FromQuery] int pagina = 1, [FromQuery] int tamanhoPagina = 10)
    {
        var postagens = await _postagemService.ObterFeed(usuarioId, pagina, tamanhoPagina);
        return Ok(postagens);
    }

    [HttpPost("{postagemId}/curtir/{usuarioId}")]
    public async Task<IActionResult> CurtirPostagem(Guid postagemId, Guid usuarioId)
    {
        await _postagemService.CurtirPostagem(usuarioId, postagemId);
        return NoContent();
    }

    [HttpPost("{postagemId}/comentar")]
    public async Task<IActionResult> ComentarPostagem(Guid postagemId, [FromBody] ComentarioDTO dto)
    {
        await _postagemService.ComentarPostagem(dto.UsuarioId, postagemId, dto.Texto);
        return NoContent();
    }
}