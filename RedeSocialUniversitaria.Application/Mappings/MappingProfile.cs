using AutoMapper;
using RedeSocialUniversitaria.Application.DTOs;
using RedeSocialUniversitaria.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RedeSocialUniversitaria.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Usuario, UsuarioDTO>()
            .ForMember(dest => dest.TotalSeguidores, opt => opt.MapFrom(src => src.Seguidores.Count))
            .ForMember(dest => dest.TotalSeguindo, opt => opt.MapFrom(src => src.Seguindo.Count));

        CreateMap<Postagem, PostagemDTO>()
            .ForMember(dest => dest.TotalCurtidas, opt => opt.MapFrom(src => src.Curtidas.Count))
            .ForMember(dest => dest.TotalComentarios, opt => opt.MapFrom(src => src.Comentarios.Count));

        CreateMap<Evento, EventoDTO>()
            .ForMember(dest => dest.TotalInscritos, opt => opt.MapFrom(src => src.Inscricoes.Count));
    }
}