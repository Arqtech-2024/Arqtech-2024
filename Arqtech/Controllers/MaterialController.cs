using Arqtech.Models;
using Arqtech.Repositorio;
using Arqtech.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Arqtech.Controllers
{
    public class MaterialController : Controller
    {
        private readonly MaterialRepositorio _materialRepositorio;
        public MaterialController(MaterialRepositorio materialRepositorio)
        {
            _materialRepositorio = materialRepositorio;
        }

        public IActionResult IndexMaterial()
        {
            var materiais = _materialRepositorio.BuscaTodosMateriais();
            return View(materiais);
        }

        [HttpGet]
        public IActionResult CriaMaterial() 
        {
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
