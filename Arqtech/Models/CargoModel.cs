namespace Arqtech.Models
{
    public class CargoModel
    {
        public int CargoId { get; set; }
        public string DescricaoCargo { get; set; }


        public int UsuarioId { get; set; }
        public virtual UsuarioModel Usuario { get; set; }
    }
}
