using Microsoft.AspNetCore.Mvc;
using RedeSocialUniversitaria.Application.DTOs;
using RedeSocialUniversitaria.Application.Interfaces;

namespace RedeSocialUniversitaria.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuariosController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioDTO>>> ObterTodos()
    {
        var usuarios = await _usuarioService.ObterTodos();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioDTO>> ObterPorId(Guid id)
    {
        var usuario = await _usuarioService.ObterPorId(id);
        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioDTO>> CriarUsuario([FromBody] UsuarioDTO usuarioDTO)
    {
        var usuarioCriado = await _usuarioService.Adicionar(usuarioDTO);
        return CreatedAtAction(nameof(ObterPorId), new { id = usuarioCriado.Id }, usuarioCriado);
    }

    [HttpPost("{seguidorId}/seguir/{seguidoId}")]
    public async Task<IActionResult> SeguirUsuario(Guid seguidorId, Guid seguidoId)
    {
        await _usuarioService.Seguir(seguidorId, seguidoId);
        return NoContent();
    }

    [HttpDelete("{seguidorId}/seguir/{seguidoId}")]
    public async Task<IActionResult> DeixarDeSeguirUsuario(Guid seguidorId, Guid seguidoId)
    {
        await _usuarioService.DeixarDeSeguir(seguidorId, seguidoId);
        return NoContent();
    }
}