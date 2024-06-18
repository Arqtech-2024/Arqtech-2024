using Arqtech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arqtech.Data.ConfiguracaoModelos
{
    public class ConfiguracaoImagemProjeto : IEntityTypeConfiguration<ImagemProjetoModel>
    {
        public void Configure(EntityTypeBuilder<ImagemProjetoModel> builder)
        {
            builder
                .HasKey(i => i.ImagemProjetoId);

            builder
                .HasOne(i => i.Projeto)
                .WithMany(p => p.ImagemProjeto)
                .HasForeignKey(i => i.ProjetoId);

            builder
                .Property(i => i.ImagemProjetoId)
                .ValueGeneratedOnAdd();
        }
    }
}
