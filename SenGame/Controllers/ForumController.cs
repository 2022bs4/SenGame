using Microsoft.AspNetCore.Mvc;

namespace SenGame.Controllers
{
    public class ForumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ComomunityHome()
        {
            return View();
        }
        public IActionResult ComomunityDynamicwall()
        {
            return View();
        }
    }
}
