using Arqtech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arqtech.Data.ConfiguracaoModelos
{
    public class ConfiguracaoCargo : IEntityTypeConfiguration<CargoModel>
    {
        public void Configure(EntityTypeBuilder<CargoModel> builder)
        {
            builder
                .HasKey(x => x.CargoId);

            builder
                .Property(x => x.CargoId)
                .ValueGeneratedOnAdd();
        }
    }
}
