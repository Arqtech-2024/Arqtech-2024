using Microsoft.AspNetCore.Identity;

namespace Arqtech.Models
{
    public class UsuarioModel : IdentityUser
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public bool Admin { get; set; }
        public string Licenca { get; set; }

        public int CargoId { get; set; }
        public virtual CargoModel Cargo { get; set; }


        public int ProjetoId { get; set; }
        public virtual List<ProjetoModel> Projetos { get; set; }
    }
}
