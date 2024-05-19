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

        public async Task<IActionResult> DetalhesMaterial(int materialId)
        {
            if (materialId == 0)
            {
                return NotFound();
            }

            var material = await _materialRepositorio.BuscaMaterialPorId(materialId);

            if (material is not null)
            {
                return View(material);
            }

            return View(material);
        }

        public async Task<IActionResult> EditarMaterial(int materialId)
        {
            if (materialId == 0)
            {
                return NotFound();
            }

            var loja = await _materialRepositorio.BuscaMaterialPorId(materialId);

            if (loja == null)
            {
                return NotFound();
            }

            return View(loja);
        }

        [HttpPost]
        public async Task<IActionResult> SalvarEdicaoMaterial(MaterialModel materialModel)
        {
            var loja = await _lojaRepositorio.BuscaLojaPorId(materialModel.LojaId);

            if (loja is not null)
            {
                materialModel.Loja = loja;
                await _materialRepositorio.AtualizaMaterial(materialModel);
                return RedirectToAction("IndexMaterial");
            }

            return View(materialModel);
        }

        public async Task<IActionResult> DeletarMaterial(int materialId)
        {
            if (materialId == 0)
            {
                return NotFound();
            }

            var materialEncontrado = await _materialRepositorio.BuscaMaterialPorId(materialId);

            if (materialEncontrado is not null)
            {
                await _materialRepositorio.DeletaMaterial(materialEncontrado.LojaId);
                return RedirectToAction("IndexMaterial");
            }

            return View(materialEncontrado);
        }
    }
}
