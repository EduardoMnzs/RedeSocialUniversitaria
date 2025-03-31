using RedeSocialUniversitaria.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RedeSocialUniversitaria.Domain.Entities;

namespace RedeSocialUniversitaria.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Postagem> Postagens { get; set; }
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Comentario> Comentarios { get; set; }
    public DbSet<Curtida> Curtidas { get; set; }
    public DbSet<InscricaoEvento> InscricoesEventos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração do relacionamento muitos-para-muitos entre Usuarios (Seguidores/Seguindo)
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.Seguindo)
            .WithMany(u => u.Seguidores)
            .UsingEntity<Dictionary<string, object>>(
                "UsuarioSeguidores",
                j => j.HasOne<Usuario>().WithMany().HasForeignKey("SeguindoId"),
                j => j.HasOne<Usuario>().WithMany().HasForeignKey("SeguidorId"),
                j => j.ToTable("UsuarioSeguidores"));

        // Outras configurações de modelo...
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}