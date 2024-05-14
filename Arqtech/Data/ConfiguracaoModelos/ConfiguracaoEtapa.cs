using Arqtech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arqtech.Data.ConfiguracaoModelos
{
    public class ConfiguracaoEtapa : IEntityTypeConfiguration<EtapaModel>
    {
        public void Configure(EntityTypeBuilder<EtapaModel> builder)
        {
            builder
                .HasKey(e => e.EtapaId);

            builder
                .Property(e => e.EtapaId)
                .ValueGeneratedOnAdd();
        }
    }
}
