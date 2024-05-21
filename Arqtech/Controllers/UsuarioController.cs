using Arqtech.Models;
using Arqtech.Repositorio;
using Arqtech.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        public async Task<IActionResult> DetalhesUsuario(string usuarioId)
        {
            if (usuarioId is null)
            {
                return NotFound();
            }
            else
            {
                var usuario = await _usuarioRepositorio.BuscaUsuarioPorId(usuarioId);

                if (usuario is not null)
                {
                    return View(usuario);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpGet]
        public IActionResult CriaUsuario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriaUsuario(CriaUsuarioViewModel criaUsuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var usuarioCriado = await _usuarioRepositorio.CriaUsuario(criaUsuarioViewModel);

                if (usuarioCriado.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("Registro", "Falha ao registrar usuário!");
                }
            }

            return View(criaUsuarioViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LogaUsuarioViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            var user = await _userManager.FindByNameAsync(loginViewModel.Email);

            if (user is not null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Password", "Senha incorreta, tente novamente");
                }
            }
            else
            {
                ModelState.AddModelError("UserName", "Esse e-mail não está em nosso sistema");
            }

            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
