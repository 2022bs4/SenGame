using Microsoft.AspNetCore.Mvc;
using SenGame.Service;
namespace SenGame.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShoppingCart()
        {
            //var Ecpay = new EcpayService();
            //var EcpayWeb = Ecpay.CreateOrder();
            return View();
            //return View(EcpayWeb);
        }
    }
}
