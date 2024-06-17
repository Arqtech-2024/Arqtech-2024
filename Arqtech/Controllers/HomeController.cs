using Arqtech.Data;
using Arqtech.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Arqtech.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Agenda()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarEvento(string title, DateTime start, DateTime? end)
        {
            var evento = new EventoCalendarioModel
            {
                Title = title,
                Start = start,
                End = end
            };

            _context.EventoCalendarioModel.Add(evento);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var eventos = _context.EventoCalendarioModel.Select(e => new {
                id = e.Id,
                title = e.Title,
                start = e.Start,
                end = e.End
            }).ToList();

            return Json(eventos);
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirEvento(int id)
        {
            var evento = await _context.EventoCalendarioModel.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            _context.EventoCalendarioModel.Remove(evento);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
