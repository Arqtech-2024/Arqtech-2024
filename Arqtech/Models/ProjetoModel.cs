namespace Arqtech.Models
{
    public class ProjetoModel
    {
        public int ProjetoId { get; set; }
        public double ValorPedreiro { get; set; }
        public double ValorMaterial { get; set; }
        public double ValorProjeto { get; set; }


        public int ListaMaterialId { get; set; }
        public virtual ListaMaterialModel ListaMaterial { get; set; }


        public int UsuarioId { get; set; }
        public virtual UsuarioModel Usuario { get; set; }

        public int EtapaId { get; set; }
        public List<EtapaModel> Etapas { get; set; }
    }
}
