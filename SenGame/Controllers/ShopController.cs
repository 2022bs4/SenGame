using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using SqlModels.Models;
using SqlModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SenGame.Controllers
{
    public class ShopController : Controller
    {
        private readonly IService _service;

        public ShopController(IService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ProductDetails(int id = 1)
        {
           
            var typelist = _service.GetAll<Typelist>();
            var gameType = _service.GetAll<GameType>().Where(x => x.GameId == id);
            var productList = gameType.Join(typelist, g => g.TypelistId, s => s.TypelistId, (g, s) => new { g.GameId, s.Name });

            var games = _service.GetById<Game>(id);
            var pic = _service.GetAll<GameMedium>().Where(x =>x.GameId == id && x.InstructionType == 2 && x.Instruction == 1).First();
            var system = _service.GetAll<SystemSpecification>().Where(x => x.GameId == id);

            var productDetailsViewModels = new List<ProductDetailsViewModel>();
            foreach (var item in system)
            {
                productDetailsViewModels.Add(new ProductDetailsViewModel
                {
                    GameId = games.GameId,
                    GameName = games.GameName,
                    GamePrice = games.GamePrice,
                    GameIntroduction = games.GameIntroduction,
                    GameDetailsText = games.GameDetailsText,
                    ReleaseTime = games.ReleaseTime,
                    Developer = games.Developer,
                    Marker = games.Marker,
                    SystemType = item.SystemType,
                    Configure = item.Configure,
                    SystemCpu = item.SystemCpu,
                    SystemGpu = item.SystemGpu,
                    Hddspace = item.Hddspace,
                    System = item.System,
                    SystemRam = item.SystemRam,
                    MediaUrl = pic.MediaUrl,
                });
            }



            return View(productDetailsViewModels);
        }


        //幻燈片
        [HttpPost]
        public IActionResult ProductSwipper(int id = 1)
        {
            var media = _service.GetAll<GameMedium>().Where(x => x.GameId == id && x.InstructionType == 1 && x.Instruction == 1).OrderBy(x => x.Sort).ToList();
            return Json(media);
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
