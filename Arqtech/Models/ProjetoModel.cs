namespace Arqtech.Models
{
    public class ProjetoModel
    {
        public int ProjetoId { get; set; }
        public string Nome { get; set; }
        public double ValorPedreiro { get; set; }
        public double ValorMaterial { get; set; }
        public double ValorProjetoArquiteto { get; set; }
        public double ValorTotalProjeto { get; set; }

        public int? ListaMaterialId { get; set; }
        public virtual ListaMaterialModel? ListaMaterial { get; set; }

        public string UsuarioId { get; set; }
        public virtual UsuarioModel Usuario { get; set; }

        public int? EtapaId { get; set; }
        public virtual List<EtapaModel>? Etapas { get; set; }
    }
}
