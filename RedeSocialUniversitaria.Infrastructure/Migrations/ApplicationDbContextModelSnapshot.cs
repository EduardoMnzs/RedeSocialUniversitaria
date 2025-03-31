﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RedeSocialUniversitaria.Infrastructure.Data;

#nullable disable

namespace RedeSocialUniversitaria.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Comentario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AutorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PostagemId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("PostagemId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("Curtida", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PostagemId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PostagemId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Curtidas");
                });

            modelBuilder.Entity("Evento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("ExigeInscricao")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("InscricaoEvento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataInscricao")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("EventoId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("InscricoesEventos");
                });

            modelBuilder.Entity("Postagem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AutorId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.ToTable("Postagens");
                });

            modelBuilder.Entity("RedeSocialUniversitaria.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Curso")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("UsuarioSeguidores", b =>
                {
                    b.Property<Guid>("SeguidorId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SeguindoId")
                        .HasColumnType("char(36)");

                    b.HasKey("SeguidorId", "SeguindoId");

                    b.HasIndex("SeguindoId");

                    b.ToTable("UsuarioSeguidores", (string)null);
                });

            modelBuilder.Entity("Comentario", b =>
                {
                    b.HasOne("RedeSocialUniversitaria.Domain.Entities.Usuario", "Autor")
                        .WithMany("Comentarios")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Postagem", "Postagem")
                        .WithMany("Comentarios")
                        .HasForeignKey("PostagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Postagem");
                });

            modelBuilder.Entity("Curtida", b =>
                {
                    b.HasOne("Postagem", "Postagem")
                        .WithMany("Curtidas")
                        .HasForeignKey("PostagemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RedeSocialUniversitaria.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Curtidas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Postagem");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("InscricaoEvento", b =>
                {
                    b.HasOne("Evento", "Evento")
                        .WithMany("Inscricoes")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RedeSocialUniversitaria.Domain.Entities.Usuario", "Usuario")
                        .WithMany("InscricoesEventos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Postagem", b =>
                {
                    b.HasOne("RedeSocialUniversitaria.Domain.Entities.Usuario", "Autor")
                        .WithMany("Postagens")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("UsuarioSeguidores", b =>
                {
                    b.HasOne("RedeSocialUniversitaria.Domain.Entities.Usuario", null)
                        .WithMany()
                        .HasForeignKey("SeguidorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RedeSocialUniversitaria.Domain.Entities.Usuario", null)
                        .WithMany()
                        .HasForeignKey("SeguindoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Evento", b =>
                {
                    b.Navigation("Inscricoes");
                });

            modelBuilder.Entity("Postagem", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("Curtidas");
                });

            modelBuilder.Entity("RedeSocialUniversitaria.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("Curtidas");

                    b.Navigation("InscricoesEventos");

                    b.Navigation("Postagens");
                });
#pragma warning restore 612, 618
        }
    }
}
