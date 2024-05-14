using System.Globalization;
using System.Reflection.PortableExecutable;

namespace Arqtech.Models
{
    public class LojaModel
    {
        public int LojaId { get; set; }
        public string Nome { get; set; }

        public int MaterialId { get; set; }
        public List<MaterialModel> Materiais { get; set; }
    }
}
