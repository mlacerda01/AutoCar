using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoCar.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutoCar.Controllers
{
    public class CarrosController : Controller
    {

        private readonly Contexto _contexto;

        public CarrosController(Contexto contexto)
        {
            _contexto = contexto;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var lista =_contexto.Carros.ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult NovoCarro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NovoCarro(Carro carro)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(carro);
                _contexto.SaveChanges();
                return RedirectToAction("Index", "Carros");
            }

            return View(carro);
        }

        [HttpGet]
        public IActionResult AtualizarCarro(int? id)
        {
            if (id == null)
                return NotFound();

            var carro = _contexto.Carros.Find(id);
            return View(carro);
        }

        [HttpPost]
        public IActionResult AtualizarCarro(Carro carro)
        {
            if (carro == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                _contexto.Update(carro);
                _contexto.SaveChanges();
                return RedirectToAction("Index", "Carros");
            }

            return View(carro);
        }

        [HttpGet]
        public IActionResult Detalhes(int? id)
        {
            if (id == null)
                return NotFound();

            var carro = _contexto.Carros.Find(id);
            return View(carro);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null)
                return NotFound();

            var carro = _contexto.Carros.Find(id);
            return View(carro);
        }

        [HttpPost]
        [ActionName("Excluir")]
        public IActionResult ConfirmarExclusao(int? id)
        {
            if (id == null)
                return NotFound();

            var carro = _contexto.Carros.Find(id);
            _contexto.Carros.Remove(carro);
            _contexto.SaveChanges();

            return RedirectToAction("Index", "Carros");
        }
    }
}
