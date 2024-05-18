using Arqtech.Data;
using Arqtech.Models;
using Arqtech.ViewModels;

namespace Arqtech.Repositorio
{
    public class ListaMaterialRepositorio
    {
        private readonly AppDbContext _context;

        public ListaMaterialRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CriaListaMaterial(ListaMaterialModel listaMaterial)
        {
            var listaMaterialCriada = false;

            try
            {
                await _context.ListaDeMateriais.AddAsync(listaMaterial);
                await _context.SaveChangesAsync();

                listaMaterialCriada = true;
            }
            catch (Exception)
            {
                listaMaterialCriada = false;
            }

           return listaMaterialCriada;
        }
    }
}
