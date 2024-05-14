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
        }
    }
}
