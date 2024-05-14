namespace Arqtech.Models
{
    public class EtapaModel
    {
        public int EtapaId { get; set; }
        public int MaterialId { get; set; }
        public int Quantidade { get; set; }
        public string NomeEtapa { get; set; }
        public string DescricaoEtapa { get; set; }
        public int DiasCorridos { get; set; }


        public int ProjetoId { get; set; }
        public ProjetoModel Projeto { get; set; }
    }
}
