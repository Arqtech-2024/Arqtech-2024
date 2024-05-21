﻿using Arqtech.Models;
using Arqtech.Repositorio;
using Arqtech.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Execution;

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
                if (User.IsInRole("Admin"))
                {
                    var projetos = await _projetoRepositorio.BuscaTodosProjetos();
                    return View(projetos);
                }
                else
                {
                    var projetos = await _projetoRepositorio.BuscaProjetosPorUsuario(usuario.Id);
                    return View(projetos);
                }
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

        [HttpPost]
        public async Task<bool> CriarListaMaterial([FromBody] List<CriaListaMaterialViewModel> itensMateriais)
        {
            var listaMaterias = new ListaMaterialModel();
            foreach (var material in itensMateriais)
            {
                var quantidadeMateriais = itensMateriais.Count;
                int posicaoIndex = 0;

                if (quantidadeMateriais == posicaoIndex)
                {
                    var projeto = await _projetoRepositorio.BuscaProjetoPorId(material.ProjetoId);
                }

                var materialEncontrado = await _materialRepositorio.BuscaMaterialPorId(material.MaterialId);

                if (materialEncontrado is not null)
                {

                }

                posicaoIndex++;
            }

            return true;
        }

        [HttpGet]
        public async Task<IActionResult> EditarProjeto(int projetoId)
        {
            var projeto = await _projetoRepositorio.BuscaProjetoPorId(projetoId);

            if(projeto is not null)
            {
                return View(projeto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]  
        public async Task<IActionResult> EditarProjeto(ProjetoModel projeto)
        {
            var usuario = await _userManager.GetUserAsync(User);

            if (projeto is not null)
            {
                projeto.Usuario = usuario;
                projeto.UsuarioId = usuario.Id;
                await _projetoRepositorio.AtualizaProjeto(projeto);

                return RedirectToAction("IndexProjeto");
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> DeletarProjeto(int projetoId)
        {
            if (projetoId == 0)
            {
                return NotFound();
            }

            var projetoEncontrado = await _projetoRepositorio.BuscaProjetoPorId(projetoId);

            if (projetoEncontrado is not null)
            {
                await _projetoRepositorio.RemoveProjeto(projetoEncontrado);
                return RedirectToAction("IndexProjeto");
            }

            return View(projetoEncontrado);
        }
    }
}
