using Arqtech.Data.ConfiguracaoModelos;
using Arqtech.Models;
using Microsoft.EntityFrameworkCore;

namespace Arqtech.Data
{
    public class AppDbContext : DbContext
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
            modelBuilder.ApplyConfiguration(new ConfiguracaoUsuario());
            modelBuilder.ApplyConfiguration(new ConfiguracaoProjeto());
            modelBuilder.ApplyConfiguration(new ConfiguracaoLoja());
        }
    }
}
