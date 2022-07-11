using Microsoft.AspNetCore.Mvc;

namespace SenGame.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
