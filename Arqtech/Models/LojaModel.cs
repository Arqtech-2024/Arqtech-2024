namespace Arqtech.Models
{
    public class LojaModel
    {
        public int LojaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }

        public virtual List<MaterialModel> Materiais { get; set; }
    }
}
