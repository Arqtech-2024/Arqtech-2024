using Arqtech.Data;
using Arqtech.Models;
using Arqtech.Models.Enums;
using Arqtech.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Arqtech.Repositorio
{
    public class UsuarioRepositorio
    {
        private readonly AppDbContext _context;
        private readonly UserManager<UsuarioModel> _userManager;

        public UsuarioRepositorio(AppDbContext context, UserManager<UsuarioModel> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<UsuarioModel>> BuscaTodosUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task AtualizaUsuario(UsuarioModel usuario)
        {
            _context.Attach(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public TipoCargoEnum VerificaCargoUsuario(string cargo)
        {
            TipoCargoEnum tipoUsuario;

            switch (cargo)
            {
                case "Engenheiro":
                    tipoUsuario = TipoCargoEnum.Engenheiro;
                    break;
                case "Arquiteto":
                    tipoUsuario = TipoCargoEnum.Arquiteto;
                    break;
                case "Admin":
                    tipoUsuario = TipoCargoEnum.Admin;
                    break;
                case "Cliente":
                    tipoUsuario = TipoCargoEnum.Cliente;
                    break;
                default: throw new NotImplementedException();
            }

            return tipoUsuario;
        }

        public async Task<IdentityResult> CriaUsuario(CriaUsuarioViewModel criaUsuarioViewModel)
        {
            var tipoCargo = VerificaCargoUsuario(criaUsuarioViewModel.Cargo);

            var usuarioModel = new UsuarioModel()
            {
                Nome = criaUsuarioViewModel.Nome,
                Sobrenome = criaUsuarioViewModel.Sobrenome,
                DataNascimento = criaUsuarioViewModel.DataNascimento,
                Cpf = criaUsuarioViewModel.Cpf,
                UserName = criaUsuarioViewModel.Email,
                Licenca = criaUsuarioViewModel.Licenca,
                Cargo = tipoCargo,
            };

            var usuarioCriado = await _userManager.CreateAsync(usuarioModel, criaUsuarioViewModel.Senha);

            if (usuarioCriado.Succeeded)
            {
                await AdicionaRoleUsuario(tipoCargo, usuarioModel);
            }

            return usuarioCriado;
        }

        public async Task AdicionaRoleUsuario(TipoCargoEnum tipoCargo, UsuarioModel usuario)
        {
            switch (tipoCargo)
            {
                case TipoCargoEnum.Admin:
                    await _userManager.AddToRoleAsync(usuario, "Admin");
                    break;
                case TipoCargoEnum.Cliente:
                    await _userManager.AddToRoleAsync(usuario, "Cliente");
                    break;
                case TipoCargoEnum.Engenheiro:
                    await _userManager.AddToRoleAsync(usuario, "Engenheiro");
                    break;
                case TipoCargoEnum.Arquiteto:
                    await _userManager.AddToRoleAsync(usuario, "Arquiteto");
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public async Task<UsuarioModel> BuscaUsuarioPorId(string usuarioId)
        {
            return await _context.Usuarios.Where(u => u.Id == usuarioId).FirstAsync();
        }
    }
}
