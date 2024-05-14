using Arqtech.Data;
using Arqtech.Models;
using Microsoft.EntityFrameworkCore;

namespace Arqtech.Repositorio
{
    public class UsuarioRepositorio
    {
        private readonly AppDbContext _context;

        public UsuarioRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioModel> BuscaUsuarioPorId(string usuarioId)
        {
            return await _context.Usuarios
                            .Where(u => u.Id == usuarioId)
                            .FirstOrDefaultAsync();
        }

        public async Task<List<UsuarioModel>> BuscaTodosUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task CriaUsuarioAsync(UsuarioModel usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizaUsuario(UsuarioModel usuario)
        {
            _context.Attach(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
