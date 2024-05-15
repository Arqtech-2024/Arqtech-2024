using System.ComponentModel.DataAnnotations;

namespace Arqtech.ViewModels
{
    public class LogaUsuarioViewModel
    {
        [Required(ErrorMessage = "O campo de E-mail é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo de senha é obrigatório")]
        public string Password { get; set; }
    }
}
