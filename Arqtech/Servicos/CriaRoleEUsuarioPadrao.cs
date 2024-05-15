using Arqtech.Models;
using Arqtech.Models.Enums;
using Arqtech.Servicos.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Arqtech.Servicos
{
    public class CriaRoleEUsuarioPadrao : ICriaRoleEUsuarioPadrao
    {
        private readonly UserManager<UsuarioModel> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CriaRoleEUsuarioPadrao(RoleManager<IdentityRole> roleManager, UserManager<UsuarioModel> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void CriaRoles()
        {
            if (!_roleManager.RoleExistsAsync("Cliente").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Cliente";
                role.NormalizedName = "CLIENTE";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Engenheiro").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Engenheiro";
                role.NormalizedName = "ENGENHEIRO";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Arquiteto").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Arquiteto";
                role.NormalizedName = "ARQUITETO";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }

        public void CriaUsuarios()
        {
            if (_userManager.FindByEmailAsync("cliente@teste.com").Result == null)
            {
                var user = new UsuarioModel();

                user.Nome = "Cliente";
                user.Sobrenome = "Dhiego";
                user.UserName = "cliente@teste.com";
                user.Email = "cliente@teste.com";
                user.NormalizedUserName = "CLIENTE@LOCALHOST";
                user.Cpf = "11111111111";
                user.EmailConfirmed = true;
                user.Cargo = TipoCargoEnum.Cliente;
                user.DataNascimento = DateTime.Now;

                IdentityResult result = _userManager.CreateAsync(user, "Cliente@123").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "cliente").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("engenheiro@teste.com").Result == null)
            {
                var user = new UsuarioModel();

                user.Nome = "Engenheiro";
                user.Sobrenome = "Dhiego";
                user.UserName = "engenheiro@teste.com";
                user.Email = "engenheiro@teste.com";
                user.NormalizedUserName = "ENGENHEIRO@TESTE.COM";
                user.Cpf = "22222222222";
                user.Cargo = TipoCargoEnum.Engenheiro;
                user.DataNascimento = DateTime.Now;
                user.Admin = false;

                IdentityResult result = _userManager.CreateAsync(user, "Engenheiro@123").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Engenheiro").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("arquiteto@teste.com").Result == null)
            {
                var user = new UsuarioModel();

                user.Nome = "Arquiteto";
                user.Sobrenome = "Caio";
                user.UserName = "arquiteto@teste.com";
                user.Email = "arquiteto@teste.com";
                user.NormalizedUserName = "ARQUITETO@TESTE.COM";
                user.Cpf = "33333333333";
                user.Cargo = TipoCargoEnum.Arquiteto;
                user.DataNascimento = DateTime.Now;
                user.Admin = false;

                IdentityResult result = _userManager.CreateAsync(user, "Arquiteto@123").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Arquiteto").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("admin@teste.com").Result == null)
            {
                var user = new UsuarioModel();

                user.Nome = "Admin";
                user.Sobrenome = "Caio";
                user.UserName = "admin@teste.com";
                user.Email = "admin@teste.com";
                user.NormalizedUserName = "ADMIN@TESTE.COM";
                user.Cpf = "55555555555";
                user.Cargo = TipoCargoEnum.Admin;
                user.DataNascimento = DateTime.Now;
                user.Admin = true;

                IdentityResult result = _userManager.CreateAsync(user, "Admin@123").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
