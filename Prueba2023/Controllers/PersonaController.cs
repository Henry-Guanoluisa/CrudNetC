using Microsoft.AspNetCore.Mvc;
using Prueba2023.Data;
using Prueba2023.Models;

namespace Prueba2023.Controllers
{
    public class PersonaController : Controller
    {
        private readonly IPersona _ipersona;

        public PersonaController(IPersona ipersona)
        {
            _ipersona = ipersona;
        }

        public IActionResult Index()
        {
            var persona = _ipersona.ObtenerPersonas();
            return View(persona);
        }

        public IActionResult Detalle(int id)
        {
            var persona = _ipersona.ObtenerPersonaPorId(id);
            return View(persona);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearTest(Persona persona)
        {
            _ipersona.InsertarPersona(persona);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var persona = _ipersona.ObtenerPersonaPorId(id);
            return View(persona);
        }

        [HttpPost]
        public IActionResult Editar(Persona persona)
        {
            _ipersona.ActualizarPersona(persona);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            var persona = _ipersona.ObtenerPersonaPorId(id);

            if (persona == null)
                return NotFound();

            return View(persona);
        }

        [HttpPost]
        public IActionResult EliminarConfirmado(int id)
        {
            _ipersona.EliminarPersona(id);
            return RedirectToAction("Index");
        }

    }
}
