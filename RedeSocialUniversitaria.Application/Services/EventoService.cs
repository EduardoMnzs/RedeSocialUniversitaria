using AutoMapper;
using RedeSocialUniversitaria.Domain.Interfaces;

public class EventoService : IEventoService
{
    private readonly IEventoRepository _eventoRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;

    public EventoService(IEventoRepository eventoRepository,
                        IUsuarioRepository usuarioRepository,
                        IMapper mapper)
    {
        _eventoRepository = eventoRepository;
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
    }

    public async Task<EventoDTO> ObterPorId(Guid id)
    {
        var evento = await _eventoRepository.ObterPorId(id);
        if (evento == null)
            return null;

        var eventoDTO = _mapper.Map<EventoDTO>(evento);
        return eventoDTO;
    }

    public async Task<EventoDTO> CriarEvento(EventoDTO eventoDTO)
    {
        var evento = new Evento(
            eventoDTO.Nome,
            eventoDTO.Local,
            eventoDTO.Descricao,
            eventoDTO.DataHora,
            eventoDTO.ExigeInscricao);

        await _eventoRepository.Adicionar(evento);
        return _mapper.Map<EventoDTO>(evento);
    }

    public async Task<IEnumerable<EventoDTO>> ObterProximosEventos()
    {
        var eventos = await _eventoRepository.ObterProximosEventos(DateTime.UtcNow);
        return _mapper.Map<IEnumerable<EventoDTO>>(eventos);
    }

    public async Task InscreverEmEvento(Guid usuarioId, Guid eventoId)
    {
        var usuario = await _usuarioRepository.ObterPorId(usuarioId);
        var evento = await _eventoRepository.ObterPorId(eventoId);

        if (usuario == null || evento == null)
            throw new ApplicationException("Usuário ou evento não encontrados");

        if (!evento.ExigeInscricao)
            return; // Evento não exige inscrição

        if (await _eventoRepository.UsuarioEstaInscrito(eventoId, usuarioId))
            return; // Já está inscrito

        var inscricao = new InscricaoEvento(usuario, evento);
        evento.AdicionarInscricao(inscricao);
        await _eventoRepository.Atualizar(evento);
    }
}