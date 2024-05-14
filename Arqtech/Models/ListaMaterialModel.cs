namespace Arqtech.Models
{
    public class ListaMaterialModel
    {
        public int ListaMaterialId { get; set; }


        public int MaterialId { get; set; }
        public virtual List<MaterialModel> Materiais { get; set; }
    }
}
