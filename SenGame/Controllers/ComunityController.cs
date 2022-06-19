using Microsoft.AspNetCore.Mvc;

namespace SenGame.Controllers
{
    public class ComunityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //顯示討論區
        public IActionResult Forum() { return View(); }
        public IActionResult ComomunityDynamicwall()
        {
            return View();
        }
    }
}
