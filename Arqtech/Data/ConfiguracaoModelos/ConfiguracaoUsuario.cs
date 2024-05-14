using Arqtech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arqtech.Data.ConfiguracaoModelos
{
    public class ConfiguracaoUsuario : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(u => u.UsuarioId);
        }
    }
}
