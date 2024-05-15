using Arqtech.Data.ConfiguracaoModelos;
using Arqtech.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Arqtech.Data
{
    public class AppDbContext : IdentityDbContext<UsuarioModel>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<LojaModel> Lojas { get; set; }
        public DbSet<EtapaModel> Etapas { get; set; }
        public DbSet<ProjetoModel> Projetos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<MaterialModel> Materiais { get; set; }
        public DbSet<ListaMaterialModel> ListaDeMateriais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ConfiguracaoLoja());
            modelBuilder.ApplyConfiguration(new ConfiguracaoEtapa());
            modelBuilder.ApplyConfiguration(new ConfiguracaoProjeto());
            modelBuilder.ApplyConfiguration(new ConfiguracaoUsuario());
            modelBuilder.ApplyConfiguration(new ConfiguracaoMaterial());
            modelBuilder.ApplyConfiguration(new ConfiguracaoListaMaterial());
        }
    }
}
