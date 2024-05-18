using Arqtech.Models;
using Arqtech.Repositorio;
using Arqtech.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Arqtech.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly ProjetoRepositorio _projetoRepositorio;
        private readonly UserManager<UsuarioModel> _userManager;
        private readonly MaterialRepositorio _materialRepositorio;

        public ProjetoController(ProjetoRepositorio projetoRepositorio, UserManager<UsuarioModel> userManager, MaterialRepositorio materialRepositorio)
        {
            _projetoRepositorio = projetoRepositorio;
            _userManager = userManager;
            _materialRepositorio = materialRepositorio;
        }

        public async Task<IActionResult> IndexProjeto()
        {
            var usuario = await _userManager.GetUserAsync(User);

            if (usuario is not null)
            {
                var projetos = await _projetoRepositorio.BuscaProjetosPorUsuario(usuario.Id);
                return View(projetos);
            }

            return View();
        }

        [HttpGet]
        public IActionResult CriaProjeto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriaProjeto(CriaProjetoViewModel criaProjetoViewModel)
        {
            var usuario = await _userManager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                if (usuario is not null)
                {
                    var projetoCriado = await _projetoRepositorio.CriaProjetoAsync(criaProjetoViewModel, usuario);

                    if (projetoCriado)
                    {
                        return RedirectToAction("IndexProjeto");
                    }
                }
                else
                {
                    ModelState.AddModelError("Usuário", "Usuário não encontrado!");
                }
            }

            return View(criaProjetoViewModel);
        }

        public async Task<IActionResult> DetalhesProjeto(int projetoId)
        {
            var projeto = await _projetoRepositorio.BuscaProjetoPorId(projetoId);

            if (projeto is null)
            {
                return NotFound();
            }

            ViewBag.Materiais = await _materialRepositorio.BuscaTodosMateriais();

            return View(projeto);
        }

        public async Task<bool> CriarListaMaterial([FromBody] List<KeyValuePair<int, int>> materiaisSelecionados)
        {
            var listaDeMaterial = new List<MaterialModel>();

            foreach(var item in materiaisSelecionados)
            {
                var id = item.Key;
                var qtde = item.Value;
            }

            return true;
        }
    }   
}
