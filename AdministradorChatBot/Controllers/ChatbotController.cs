using Microsoft.AspNetCore.Mvc;

namespace AdministradorChatBot.Controllers
{
    public class ChatbotController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(string nombre)
        {


            return RedirectToAction("Index");
        }
    }
}
