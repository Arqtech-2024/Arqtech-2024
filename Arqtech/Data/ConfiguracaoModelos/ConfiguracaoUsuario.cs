using Arqtech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arqtech.Data.ConfiguracaoModelos
{
    public class ConfiguracaoUsuario : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder
                .HasKey(u => u.UsuarioId);

            builder
                .Property(u => u.UsuarioId)
                .ValueGeneratedOnAdd();

            builder
                .HasOne(u => u.Cargo)
                .WithOne(c => c.Usuario)
                .HasForeignKey<UsuarioModel>(u => u.CargoId);
        }
    }
}
