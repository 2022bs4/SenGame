using Microsoft.AspNetCore.Mvc;

namespace SenGame.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Game()
        {
            return View();
        }

        public IActionResult Game_Category()
        {
            return View();
        }
    }
}
