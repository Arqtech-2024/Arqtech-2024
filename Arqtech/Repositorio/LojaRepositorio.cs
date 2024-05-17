using Arqtech.Data;
using Arqtech.Models;
using Microsoft.EntityFrameworkCore;

namespace Arqtech.Repositorio
{
    public class LojaRepositorio
    {
        private readonly AppDbContext _context;
        public LojaRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<LojaModel> BuscaLojaPorId(int lojaId)
        {
            return await _context.Lojas.Where(l => l.LojaId == lojaId).FirstAsync();
        }

        public async Task<List<LojaModel>> BuscaTodasLojas()
        {
            return await _context.Lojas.ToListAsync();
        }

        public async Task<bool> CriaLoja(LojaModel loja)
        {
            bool lojaCriada = false;
            
            try
            {
                await _context.Lojas.AddAsync(loja);
                await _context.SaveChangesAsync();
                lojaCriada = true;
            }
            catch (Exception ex)
            {
                lojaCriada = false;
            }

            return lojaCriada;
        }

        public async Task AtualizaLoja(LojaModel loja)
        {
            _context.Attach(loja).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletaLoja(int lojaId)
        {
            var loja = await BuscaLojaPorId(lojaId);

            if (loja is not null)
            {
                _context.Lojas.Remove(loja);
                _context.SaveChanges();
            }
        }
    }
}
