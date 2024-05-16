namespace Arqtech.Models
{
    public class MaterialModel
    {
        public int MaterialId { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string? Descricao { get; set; }

        public int LojaId { get; set; }
        public virtual LojaModel Loja { get; set; }

        public virtual ListaMaterialModel? ListaMateriais { get; set; }
    }
}
