using Arqtech.Models;
using Arqtech.Repositorio;
using Arqtech.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Arqtech.Controllers
{
    public class MaterialController : Controller
    {
        private readonly MaterialRepositorio _materialRepositorio;
        private readonly LojaRepositorio _lojaRepositorio;
        public MaterialController(MaterialRepositorio materialRepositorio, LojaRepositorio lojaRepositorio)
        {
            _materialRepositorio = materialRepositorio;
            _lojaRepositorio = lojaRepositorio;
        }

        public async Task<IActionResult> IndexMaterial()
        {
            var materiais = await _materialRepositorio.BuscaTodosMateriais();
            return View(materiais);
        }

        [HttpGet]
        public async Task<IActionResult> CriaMaterial() 
        {
            ViewBag.Lojas = await _lojaRepositorio.BuscaTodasLojas();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriaMaterial(CriaMaterialViewModel criaMaterialViewModel)
        {
            if (ModelState.IsValid)
            {
                var materialCriado = await _materialRepositorio.CriaMaterial(criaMaterialViewModel);

                if (materialCriado)
                {
                    return RedirectToAction("IndexMaterial");
                }
            }
            
            return View(criaMaterialViewModel);
        }
    }
}
