using System.ComponentModel.DataAnnotations;

namespace Arqtech.ViewModels
{
    public class CriaLojaViewModel
    {
        [Required(ErrorMessage="Insira o nome da loja")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Insira a descricão da loja")]
        public string Descricao { get; set; }


        [Required(ErrorMessage = "Insira o logradouro da loja")]
        public string Logradouro { get; set; }


        [Required(ErrorMessage = "Insira o número da loja")]
        public string Numero { get; set; }


        [Required(ErrorMessage = "Insira a cidade da loja")]
        public string Cidade { get; set; }
    }
}
