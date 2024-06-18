namespace Arqtech.Models
{
    public class ImagemProjetoModel
    {
        public int ImagemProjetoId { get; set; }
        public string? Imagem { get; set; }

        public int ProjetoId { get; set; }
        public virtual ProjetoModel Projeto { get; set; }
    }
}
