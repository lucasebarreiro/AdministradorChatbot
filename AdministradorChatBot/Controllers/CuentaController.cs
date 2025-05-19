using Microsoft.AspNetCore.Mvc;

namespace AdministradorChatBot.Controllers
{
    public class CuentaController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string nombreUsuario, string contraseña)
        {

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(string nombreUsuario, string contraseña)
        {

            return RedirectToAction("Login");
        }
    }
}
