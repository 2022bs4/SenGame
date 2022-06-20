using Microsoft.AspNetCore.Mvc;

namespace SenGame.Controllers
{
    public class FriendController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Chat()
        {
            return View();
        }
        public IActionResult member__information()
        {
            return View();
        }
    }
}
