using Arqtech.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace Arqtech.Models
{
    public class UsuarioModel : IdentityUser
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public bool Admin { get; set; }
        public string? Licenca { get; set; }
        public TipoCargoEnum Cargo { get; set; }

        public int ProjetoId { get; set; }
        public virtual List<ProjetoModel>? Projetos { get; set; }
    }
}
