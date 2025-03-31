using Microsoft.Extensions.DependencyInjection;
using RedeSocialUniversitaria.Application.Interfaces;
using RedeSocialUniversitaria.Application.Services;
using System.Reflection;

namespace RedeSocialUniversitaria.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IPostagemService, PostagemService>();
        services.AddScoped<IEventoService, EventoService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}