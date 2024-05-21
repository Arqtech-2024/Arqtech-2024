using Arqtech.Data;
using Arqtech.Models;
using Arqtech.ViewModels;
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

        public async Task<bool> CriaProjetoAsync(CriaProjetoViewModel criaProjetoViewModel, UsuarioModel usuario)
        {
            bool projetoCriado = false;

            if (criaProjetoViewModel is not null && usuario is not null)
            {
                var projeto = new ProjetoModel
                {
                    Usuario = usuario,
                    UsuarioId = usuario.Id,
                    Nome = criaProjetoViewModel.Nome,
                    Cidade = criaProjetoViewModel.Cidade,
                    Logradouro = criaProjetoViewModel.Logradouro,
                    Numero = criaProjetoViewModel.Numero,
                    ValorMaterial = criaProjetoViewModel.ValorMaterial,
                    ValorPedreiro = criaProjetoViewModel.ValorPedreiro,
                    ValorProjetoArquiteto = criaProjetoViewModel.ValorProjetoArquiteto,
                    ValorTotalProjeto = criaProjetoViewModel.ValorTotalProjeto,
                };

                try
                {
                    await _context.AddAsync(projeto);
                    await _context.SaveChangesAsync();
                    projetoCriado = true;
                }
                catch (Exception)
                {
                    projetoCriado = false;
                }
            }

            return projetoCriado;
        }

        public async Task<ProjetoModel> BuscaProjetoPorId(int projetoId)
        {
            return await _context.Projetos
                                 .Where(p => p.ProjetoId == projetoId)
                                 .Include(p => p.Usuario)
                                 .Include(p => p.ListaMaterial)
                                 .FirstAsync();
        }

        public async Task<List<ProjetoModel>> BuscaTodosProjetos()
        {
            return await _context.Projetos.ToListAsync();
        }

        public async Task<List<ProjetoModel>> BuscaProjetosPorUsuario(string usuarioId)
        {
            return await _context.Projetos
                                 .Where(p => p.UsuarioId == usuarioId)
                                 .Include(p => p.ListaMaterial)
                                 .Include(p => p.Usuario)
                                 .ToListAsync();
        }

        public async Task AtualizaProjeto(ProjetoModel projeto)
        {
            _context.Attach(projeto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveProjeto(ProjetoModel projeto)
        {
            _context.Remove(projeto);
            await _context.SaveChangesAsync();
        }
    }
}
