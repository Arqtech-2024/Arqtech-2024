using Arqtech.Data;
using Arqtech.Models;
using Microsoft.EntityFrameworkCore;

namespace Arqtech.Repositorio
{
    public class ProjetoRepositorio
    {
        private readonly AppDbContext _context;

        public ProjetoRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task CriaProjetoAsync(ProjetoModel projeto)
        {
            await _context.AddAsync(projeto);
            await _context.SaveChangesAsync();
        }

        public async Task<ProjetoModel> BuscaProjetoPorId(int projetoId)
        {
            return await _context.Projetos.FirstOrDefaultAsync(p => p.ProjetoId == projetoId)!;
        }

        public async Task<List<ProjetoModel>> BuscaTodosProjetos()
        {
            return await _context.Projetos.ToListAsync();
        }

        public async Task<List<ProjetoModel>> BuscaProjetosPorUsuario(int usuarioId)
        {
            return await _context.Projetos
                                 .Where(p => p.UsuarioId == usuarioId)
                                 .Include(p => p.ListaMaterial)
                                 .Include(p => p.Usuario)
                                 .Include(p => p.Etapas)
                                 .ToListAsync();
        }
    }
}
