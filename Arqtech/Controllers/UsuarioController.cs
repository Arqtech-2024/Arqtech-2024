using Arqtech.Models;
using Arqtech.Repositorio;
using Arqtech.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Arqtech.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;
        private readonly UserManager<UsuarioModel> _userManager;
        private readonly SignInManager<UsuarioModel> _signInManager;
        public UsuarioController(UsuarioRepositorio usuarioRepositorio, UserManager<UsuarioModel> userManager, SignInManager<UsuarioModel> signInManager)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> IndexUsuario()
        {
            var usuarios = await _usuarioRepositorio.BuscaTodosUsuarios();
            return View(usuarios);
        }

        public async Task<IActionResult> CriaUsuario(CriaUsuarioViewModel criaUsuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var usuarioModel = new UsuarioModel()
                {
                    Nome = criaUsuarioViewModel.Nome,
                    Sobrenome = criaUsuarioViewModel.Sobrenome,
                    DataNascimento = criaUsuarioViewModel.DataNascimento,
                    Admin = false,
                };

                var usuarioCriado = await _userManager.CreateAsync(usuarioModel, usuarioModel.Senha);

                if (usuarioCriado.Succeeded)
                {
                    return RedirectToAction("IndexUsuario");
                }
                else
                {
                    ModelState.AddModelError("Registro", "Falha ao registrar usuário!");
                }
            }

            return View(criaUsuarioViewModel);
        }

        public async Task<IActionResult> Login(LogaUsuarioViewModel logaUsuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _userManager.FindByEmailAsync(logaUsuarioViewModel.Email);

                if(usuario is not null)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }
    }
}
