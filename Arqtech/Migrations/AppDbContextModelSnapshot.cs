﻿// <auto-generated />
using Arqtech.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Arqtech.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Arqtech.Models.CargoModel", b =>
                {
                    b.Property<int>("CargoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoId"));

                    b.Property<string>("DescricaoCargo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("CargoId");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("Arqtech.Models.EtapaModel", b =>
                {
                    b.Property<int>("EtapaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DescricaoEtapa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiasCorridos")
                        .HasColumnType("int");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<string>("NomeEtapa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioLista")
                        .HasColumnType("int");

                    b.HasKey("EtapaId");

                    b.ToTable("Etapas");
                });

            modelBuilder.Entity("Arqtech.Models.ListaMaterialModel", b =>
                {
                    b.Property<int>("ListaMaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ListaMaterialId"));

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.HasKey("ListaMaterialId");

                    b.ToTable("ListaDeMateriais");
                });

            modelBuilder.Entity("Arqtech.Models.LojaModel", b =>
                {
                    b.Property<int>("LojaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LojaId"));

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LojaId");

                    b.ToTable("Lojas");
                });

            modelBuilder.Entity("Arqtech.Models.MaterialModel", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("LojaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.HasKey("MaterialId");

                    b.ToTable("Materiais");
                });

            modelBuilder.Entity("Arqtech.Models.ProjetoModel", b =>
                {
                    b.Property<int>("ProjetoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjetoId"));

                    b.Property<int>("EtapaId")
                        .HasColumnType("int");

                    b.Property<int>("ListaMaterialId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<double>("ValorMaterial")
                        .HasColumnType("float");

                    b.Property<double>("ValorPedreiro")
                        .HasColumnType("float");

                    b.Property<double>("ValorProjetoArquiteto")
                        .HasColumnType("float");

                    b.Property<double>("ValorTotalProjeto")
                        .HasColumnType("float");

                    b.HasKey("ProjetoId");

                    b.HasIndex("ListaMaterialId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("Arqtech.Models.UsuarioModel", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<string>("DataNascimento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<string>("Rg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.HasIndex("CargoId")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Arqtech.Models.EtapaModel", b =>
                {
                    b.HasOne("Arqtech.Models.ProjetoModel", "Projeto")
                        .WithMany("Etapas")
                        .HasForeignKey("EtapaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("Arqtech.Models.MaterialModel", b =>
                {
                    b.HasOne("Arqtech.Models.ListaMaterialModel", "ListaMateriais")
                        .WithMany("Materiais")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Arqtech.Models.LojaModel", "Loja")
                        .WithMany("Materiais")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ListaMateriais");

                    b.Navigation("Loja");
                });

            modelBuilder.Entity("Arqtech.Models.ProjetoModel", b =>
                {
                    b.HasOne("Arqtech.Models.ListaMaterialModel", "ListaMaterial")
                        .WithMany()
                        .HasForeignKey("ListaMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Arqtech.Models.UsuarioModel", "Usuario")
                        .WithMany("Projetos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ListaMaterial");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Arqtech.Models.UsuarioModel", b =>
                {
                    b.HasOne("Arqtech.Models.CargoModel", "Cargo")
                        .WithOne("Usuario")
                        .HasForeignKey("Arqtech.Models.UsuarioModel", "CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("Arqtech.Models.CargoModel", b =>
                {
                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Arqtech.Models.ListaMaterialModel", b =>
                {
                    b.Navigation("Materiais");
                });

            modelBuilder.Entity("Arqtech.Models.LojaModel", b =>
                {
                    b.Navigation("Materiais");
                });

            modelBuilder.Entity("Arqtech.Models.ProjetoModel", b =>
                {
                    b.Navigation("Etapas");
                });

            modelBuilder.Entity("Arqtech.Models.UsuarioModel", b =>
                {
                    b.Navigation("Projetos");
                });
#pragma warning restore 612, 618
        }
    }
}
