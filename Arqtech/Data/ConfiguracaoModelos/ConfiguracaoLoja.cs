using Arqtech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arqtech.Data.ConfiguracaoModelos
{
    public class ConfiguracaoLoja : IEntityTypeConfiguration<LojaModel>
    {
        public void Configure(EntityTypeBuilder<LojaModel> builder)
        {
            builder
                .HasKey(l => l.LojaId);

            builder
                .Property(l => l.LojaId)
                .ValueGeneratedOnAdd();
        }
    }
}
