using AutoMapper;
using RedeSocialUniversitaria.Application.DTOs;
using RedeSocialUniversitaria.Application.Interfaces;
using RedeSocialUniversitaria.Domain.Entities;
using RedeSocialUniversitaria.Domain.Interfaces;

namespace RedeSocialUniversitaria.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;

    public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
    }

    public async Task<UsuarioDTO> ObterPorId(Guid id)
    {
        var usuario = await _usuarioRepository.ObterPorId(id);
        return _mapper.Map<UsuarioDTO>(usuario);
    }

    public async Task<IEnumerable<UsuarioDTO>> ObterTodos()
    {
        var usuarios = await _usuarioRepository.ObterTodos();
        return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
    }

    public async Task<UsuarioDTO> Adicionar(UsuarioDTO usuarioDTO)
    {
        var usuario = new Usuario(usuarioDTO.Nome, usuarioDTO.Email, usuarioDTO.Curso);
        await _usuarioRepository.Adicionar(usuario);
        return _mapper.Map<UsuarioDTO>(usuario);
    }

    public async Task Seguir(Guid seguidorId, Guid seguidoId)
    {
        var seguidor = await _usuarioRepository.ObterPorId(seguidorId);
        var seguido = await _usuarioRepository.ObterPorId(seguidoId);

        if (seguidor == null || seguido == null)
            throw new ApplicationException("Usuário não encontrado");

        seguidor.Seguir(seguido);
        await _usuarioRepository.Atualizar(seguidor);
        await _usuarioRepository.Atualizar(seguido);
    }

    public async Task DeixarDeSeguir(Guid seguidorId, Guid seguidoId)
    {
        var seguidor = await _usuarioRepository.ObterPorId(seguidorId);
        var seguido = await _usuarioRepository.ObterPorId(seguidoId);

        if (seguidor == null || seguido == null)
            throw new ApplicationException("Usuário não encontrado");

        seguidor.DeixarDeSeguir(seguido);
        await _usuarioRepository.Atualizar(seguidor);
        await _usuarioRepository.Atualizar(seguido);
    }
}