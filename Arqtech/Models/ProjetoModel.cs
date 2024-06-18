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
        public string? ImagemCapa { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }

        public int? ListaMaterialId { get; set; }
        public virtual ListaMaterialModel? ListaMaterial { get; set; }

        public string UsuarioId { get; set; }
        public virtual UsuarioModel Usuario { get; set; }

        public int ImagemProjetoId { get; set; }
        public virtual List<ImagemProjetoModel>? ImagemProjeto { get; set; }
    }
}
