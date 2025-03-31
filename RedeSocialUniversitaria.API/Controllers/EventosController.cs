using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    private readonly IEventoService _eventoService;

    public EventosController(IEventoService eventoService)
    {
        _eventoService = eventoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventoDTO>>> ObterProximosEventos()
    {
        var eventos = await _eventoService.ObterProximosEventos();
        return Ok(eventos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EventoDTO>> ObterPorId(Guid id)
    {
        var evento = await _eventoService.ObterPorId(id);
        if (evento == null)
            return NotFound();

        return Ok(evento);
    }

    [HttpPost]
    public async Task<ActionResult<EventoDTO>> CriarEvento([FromBody] EventoDTO eventoDTO)
    {
        var evento = await _eventoService.CriarEvento(eventoDTO);
        return CreatedAtAction(nameof(ObterPorId), new { id = evento.Id }, evento);
    }

    [HttpPost("{eventoId}/inscrever/{usuarioId}")]
    public async Task<IActionResult> InscreverEmEvento(Guid eventoId, Guid usuarioId)
    {
        await _eventoService.InscreverEmEvento(usuarioId, eventoId);
        return NoContent();
    }
}