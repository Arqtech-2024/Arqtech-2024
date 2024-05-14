using Arqtech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arqtech.Data.ConfiguracaoModelos
{
    public class ConfiguracaoListaMaterial : IEntityTypeConfiguration<ListaMaterialModel>
    {
        public void Configure(EntityTypeBuilder<ListaMaterialModel> builder)
        {
            builder
                .HasKey(l => l.ListaMaterialId);

            builder
                .Property(l => l.ListaMaterialId)
                .ValueGeneratedOnAdd();

            builder
                .HasMany(l => l.Materiais)
                .WithOne(m => m.ListaMateriais)
                .HasForeignKey(l => l.MaterialId);
        }
    }
}
