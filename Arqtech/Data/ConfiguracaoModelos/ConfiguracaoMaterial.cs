using Arqtech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arqtech.Data.ConfiguracaoModelos
{
    public class ConfiguracaoMaterial : IEntityTypeConfiguration<MaterialModel>
    {
        public void Configure(EntityTypeBuilder<MaterialModel> builder)
        {
            builder
                .HasKey(m => m.MaterialId);

            builder
                .Property(m => m.MaterialId)
                .ValueGeneratedOnAdd();

            builder
                .HasMany(m => m.listaMaterial)
                .WithMany(lm => lm.Materiais)
                .UsingEntity(j => j.ToTable("ListaMaterialMaterial"));
        }
    }
}
