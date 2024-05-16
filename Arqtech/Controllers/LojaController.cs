using Arqtech.Data;
using Arqtech.Models;
using Arqtech.Repositorio;
using Arqtech.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Arqtech.Controllers
{
    public class LojaController : Controller
    {
        private readonly LojaRepositorio _lojaRepositorio;

        public LojaController(LojaRepositorio lojaRepositorio)
        {
            _lojaRepositorio = lojaRepositorio;
        }

        public async Task<IActionResult> IndexLoja()
        {
            var lojas = await _lojaRepositorio.BuscaTodasLojas();
            return View(lojas);
        }

        [HttpGet]
        public IActionResult CriaLoja()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriaLoja(CriaLojaViewModel criaLojaViewModel)
        {
            if (criaLojaViewModel is null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var loja = new LojaModel
                {
                    Nome = criaLojaViewModel.Nome,
                    Cidade = criaLojaViewModel.Cidade,
                    Descricao = criaLojaViewModel.Descricao,
                    Numero = criaLojaViewModel.Numero,
                    Logradouro = criaLojaViewModel.Logradouro,
                };

                var lojaCriada = await _lojaRepositorio.CriaLoja(loja);

                if (lojaCriada)
                {
                    return RedirectToAction("IndexLoja");
                }
            }

            return View(criaLojaViewModel);
        }

        public async Task<IActionResult> DeletarLoja(int lojaId)
        {
            if (lojaId == 0)
            {
                return NotFound();
            }

            var lojaEncontrada = await _lojaRepositorio.BuscaLojaPorId(lojaId);

            if (lojaEncontrada is not null)
            {
                await _lojaRepositorio.DeletaLoja(lojaEncontrada.LojaId);
                return RedirectToAction("IndexLoja");
            }

            return View(lojaEncontrada);
        }

        public async Task<IActionResult> EditarLoja(int lojaId)
        {
            if (lojaId == 0)
            {
                return NotFound();
            }

            var loja = await _lojaRepositorio.BuscaLojaPorId(lojaId);

            if (loja == null)
            {
                return NotFound();
            }

            return View(loja);
        }

        [HttpPost]
        public async Task<IActionResult> SalvarEdicaoLoja(LojaModel lojaModel)
        {
            await _lojaRepositorio.AtualizaLoja(lojaModel);
            return RedirectToAction("IndexLoja");
        }
    }
}
