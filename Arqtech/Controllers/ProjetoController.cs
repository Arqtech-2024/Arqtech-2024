using Arqtech.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Arqtech.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly ProjetoRepositorio _projetoRepositorio;

        public ProjetoController(ProjetoRepositorio projetoRepositorio)
        {
            _projetoRepositorio = projetoRepositorio;
        }

        //public IActionResult Index()
        //{
        //    //var projetos = _projetoRepositorio.BuscaProjetosPorUsuario()

        //    //return View();
        //}
    }
}
