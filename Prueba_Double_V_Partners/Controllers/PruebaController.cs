using Microsoft.AspNetCore.Mvc;
using Prueba_Double_V_Partners.Models;
using Prueba_Double_V_Partners.Servicios;

namespace Prueba_Double_V_Partners.Controllers
{
    public class PruebaController : Controller
    {
        private readonly IApiCuenta apiCuenta;

        public PruebaController(IApiCuenta apiCuenta)
        {
            this.apiCuenta = apiCuenta;
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Cuenta cuenta)
        {

            if (!ModelState.IsValid)
            {
                return View(cuenta);
            }

            var res = await apiCuenta.CrearCuenta(cuenta);

            return View("ResultadoCuenta", res);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuarios usuarios)
        {

            if (!ModelState.IsValid)
            {
                return View(usuarios);
            }

            var res = await apiCuenta.ValidarLogin(usuarios);

            return View("ResultadoCuenta", res);
        }

        public IActionResult ResultadoCuenta(RespuestaCuenta respuesta)
        {
            return View(respuesta);
        }

    }
}
