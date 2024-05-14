namespace Arqtech.Models
{
    public class UsuarioModel
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Rg { get; set; }
        public string Senha { get; set; }
        public bool Admin { get; set; }


        public int CargoId { get; set; }
        public virtual CargoModel Cargo { get; set; }


        public int ProjetoId { get; set; }
        public virtual List<ProjetoModel> Projetos { get; set; }
    }
}
