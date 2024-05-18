using Arqtech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arqtech.Data.ConfiguracaoModelos
{
    public class ConfiguracaoProjeto : IEntityTypeConfiguration<ProjetoModel>
    {
        public void Configure(EntityTypeBuilder<ProjetoModel> builder)
        {
            builder
                .HasKey(p => p.ProjetoId);

            builder
                .Property(p => p.ProjetoId)
                .ValueGeneratedOnAdd();

            builder
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Projetos)
                .HasForeignKey(p => p.UsuarioId);
        }
    }
}
