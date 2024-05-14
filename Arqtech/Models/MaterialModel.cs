namespace Arqtech.Models
{
    public class MaterialModel
    {
        public int MaterialId { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }


        public int LojaId { get; set; }
        public LojaModel Loja { get; set; }


        public int ListaMaterialId { get; set; }
        public virtual ListaMaterialModel ListaMaterial { get; set; }
    }
}
