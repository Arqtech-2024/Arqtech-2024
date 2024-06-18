using Arqtech.Models;
using Arqtech.Repositorio;
using Arqtech.ViewModels;
using iText.Html2pdf;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Execution;
using Microsoft.CodeAnalysis;

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
        public async Task<IActionResult> CriarListaMaterial([FromBody] List<CriaListaMaterialViewModel> itensMateriais)
        {
            var listaMaterias = new ListaMaterialModel
            {
                Materiais = new List<MaterialModel>()
            };

            double totalListaMaterial = 0;

            var projeto = await _projetoRepositorio.BuscaProjetoPorId(itensMateriais[0].ProjetoId);

            if (projeto is not null)
            {
                for (int i = 0; i < itensMateriais.Count; i++)
                {
                    double preco = itensMateriais[i].Preco;
                    int quantidade = itensMateriais[i].Quantidade;
                    totalListaMaterial += preco * quantidade;

                    var materialEncontrado = await _materialRepositorio.BuscaMaterialPorId(itensMateriais[i].MaterialId);

                    if (materialEncontrado is not null)
                    {
                        materialEncontrado.Quantidade = quantidade;
                        listaMaterias.Materiais.Add(materialEncontrado);
                    }
                }

                projeto.ListaMaterial = listaMaterias;
                projeto.ValorMaterial = totalListaMaterial;
                projeto.ValorTotalProjeto = projeto.ValorProjetoArquiteto + projeto.ValorPedreiro + projeto.ValorMaterial;

                await _projetoRepositorio.AtualizaProjeto(projeto);

                return RedirectToAction("DetalhesProjeto", new { projetoId = projeto.ProjetoId });
            }

            return RedirectToAction("IndexProjeto");
        }

        [HttpGet]
        public async Task<IActionResult> EditarProjeto(int projetoId)
        {
            var projeto = await _projetoRepositorio.BuscaProjetoPorId(projetoId);

            if (projeto is not null)
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

        [HttpPost]
        public async Task<IActionResult> UploadImagensProjeto(int projetoId, List<IFormFile> files)
        {
            if (files != null && files.Count > 0)
            {
                var projeto = await _projetoRepositorio.BuscaProjetoPorId(projetoId);
                if (projeto == null)
                {
                    return NotFound();
                }

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await file.CopyToAsync(memoryStream);
                            var fileBytes = memoryStream.ToArray();
                            var base64String = Convert.ToBase64String(fileBytes);
                            var imagemProjeto = new ImagemProjetoModel
                            {
                                Imagem = base64String,
                                ProjetoId = projetoId
                            };
                            await _projetoRepositorio.AdicionaImagemProjeto(imagemProjeto);
                        }
                    }
                }

                return RedirectToAction("DetalhesProjeto", new { ProjetoId = projetoId });
            }

            return BadRequest("Arquivo(s) inválido(s).");
        }


        [HttpPost]
        public async Task<IActionResult> UploadImagem(int projetoId, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var projeto = await _projetoRepositorio.BuscaProjetoPorId(projetoId);
                if (projeto == null)
                {
                    return NotFound();
                }

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    var fileBytes = memoryStream.ToArray();
                    var base64String = Convert.ToBase64String(fileBytes);
                    projeto.ImagemCapa = base64String;
                }

                await _projetoRepositorio.AtualizaProjeto(projeto);

                return RedirectToAction("DetalhesProjeto", new { projetoId = projetoId });
            }

            return BadRequest("Arquivo inválido.");
        }

        public async Task<IActionResult> GerarPdfProjeto(int projetoId)
        {
            var projeto = await _projetoRepositorio.BuscaProjetoPorId(projetoId);

            if (projeto == null)
            {
                return NotFound();
            }

            var conteudoHtml = await _projetoRepositorio.RenderizarHtmlEstagio(projeto);
            var nomePdf = $"{projeto.ProjetoId}-.pdf";

            try
            {
                var memoryStream = new MemoryStream();
                var writer = new PdfWriter(memoryStream);
                var pdf = new PdfDocument(writer);
                var converter = new ConverterProperties();

                HtmlConverter.ConvertToPdf(conteudoHtml, pdf, converter);

                pdf.Close();

                return File(memoryStream.ToArray(), "application/pdf", nomePdf);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao gerar PDF: " + ex.Message);
                return RedirectToAction("IndexProjeto");
            }
        }
    }
}
