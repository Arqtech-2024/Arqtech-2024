using System.ComponentModel.DataAnnotations;

namespace Arqtech.ViewModels
{
    public class CriaUsuarioViewModel
    {
        [Required(ErrorMessage = "Insira o nome do usuário")]
        [Display(Name = "Nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira o sobrenome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Insira a data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Insira o CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Insira o e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira a senha")]
        public string Senha { get; set; }
        public string? Licenca { get; set; }

        [Required(ErrorMessage = "Selecione o seu cargo")]
        public string Cargo { get; set; }
    }
}
