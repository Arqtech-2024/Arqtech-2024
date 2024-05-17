using Arqtech.Data;
using Arqtech.Models;
using Arqtech.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Arqtech.Repositorio
{
    public class MaterialRepositorio
    {
        private readonly AppDbContext _context;

        public MaterialRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MaterialModel>> BuscaTodosMateriais()
        {
            return await _context.Materiais.ToListAsync();
        }

        public async Task<IEnumerable<MaterialModel>> BuscaTodosMateriaisPorLoja(int lojaId)
        {
            return await _context.Materiais
                                 .Where(m => m.LojaId == lojaId)
                                 .Include(m => m.Loja)
                                 .ToListAsync();
        }

        public async Task<bool> CriaMaterial(CriaMaterialViewModel criaMaterialViewModel)
        {
            bool materialCriado = false;
            var loja = await _context.Lojas.Where(c => c.LojaId == criaMaterialViewModel.LojaId).FirstAsync();

            if (loja is not null)
            {
                try
                {
                    var novoMaterial = new MaterialModel
                    {
                        Descricao = criaMaterialViewModel.Descricao,
                        Nome = criaMaterialViewModel.Nome,
                        Preco = criaMaterialViewModel.Preco,
                        Loja = loja,
                        LojaId = loja.LojaId,
                    };

                    await _context.Materiais.AddAsync(novoMaterial);
                    await _context.SaveChangesAsync();

                    materialCriado = true;
                }
                catch (Exception)
                {
                    materialCriado = false;
                }
            }

            return materialCriado;
        }

        public async Task<MaterialModel> BuscaMaterialPorId(int materialId)
        {
            return await _context.Materiais.FirstOrDefaultAsync(x => x.MaterialId == materialId);
        }

        public async Task AtualizaMaterial(MaterialModel material)
        {
            _context.Attach(material).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletaMaterial(int materialId)
        {
            var material = await BuscaMaterialPorId(materialId);

            if (material is not null)
            {
                _context.Materiais.Remove(material);
                _context.SaveChanges();
            }
        }
    }
}
