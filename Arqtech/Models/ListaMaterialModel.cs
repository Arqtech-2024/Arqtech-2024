namespace Arqtech.Models
{
    public class ListaMaterialModel
    {
        public int ListaMaterialId { get; set; }
        public virtual List<MaterialModel> Materiais { get; set; }

        public int ProjetoId { get; set; }
        public ProjetoModel Projeto { get; set; }
    }
}
