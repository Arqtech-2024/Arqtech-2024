using Arqtech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arqtech.Data.ConfiguracaoModelos
{
    public class ConfiguracaoEventoCalendario : IEntityTypeConfiguration<EventoCalendarioModel>
    {
        public void Configure(EntityTypeBuilder<EventoCalendarioModel> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
