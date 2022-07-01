//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Services.Interface;
//using SqlModels.Models;
//using SqlModels.ViewModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace SenGame.Controllers
//{
//    public class ShopController : Controller
//    {
//        private readonly IService _service;
//        public ShopController(IService service)
//        {
//            _service = service;
//        }
//        public IActionResult Index()
//        {
//            return View();
//        }


//        public IActionResult ProductDetails(int id)
//        {
//            if (id == null || id== 0)
//            {
//                return View("/Views/Home/Index.cshtml");
//            }
//           //標籤
//            var typelist = _service.GetAll<Typelist>();
//            var gameType = _service.GetAll<GameType>().Where(x => x.GameId == id);
//            var productList = gameType.Join(typelist, g => g.TypelistId, s => s.TypelistId, (g, s) => new { g.GameId, s.Name });

//            var games = _service.GetById<Game>(id);
//            var pic = _service.GetAll<GameMedium>().Where(x =>x.GameId == id && x.InstructionType == 2 && x.Instruction == 1).First();
//            var system = _service.GetAll<SystemSpecification>().Where(x => x.GameId == id);

//            var productDetailsViewModels = new List<ProductDetailsViewModel>();
//            foreach (var item in system)
//            {
//                productDetailsViewModels.Add(new ProductDetailsViewModel
//                {
//                    GameId = games.GameId,
//                    GameName = games.GameName,
//                    GamePrice = games.GamePrice,
//                    GameIntroduction = games.GameIntroduction,
//                    GameDetailsText = games.GameDetailsText,
//                    ReleaseTime = games.ReleaseTime,
//                    Developer = games.Developer,
//                    Marker = games.Marker,
//                    SystemType = item.SystemType,
//                    Configure = item.Configure,
//                    SystemCpu = item.SystemCpu,
//                    SystemGpu = item.SystemGpu,
//                    Hddspace = item.Hddspace,
//                    System = item.System,
//                    SystemRam = item.SystemRam,
//                    MediaUrl = pic.MediaUrl,
//                });
//            }



//            return View(productDetailsViewModels);
//        }


//        //幻燈片
//        [HttpPost]
//        public async Task<IActionResult> ProductSwipper(int id)
//        {
//            var media =await _service.GetAll<GameMedium>().Where(x => x.GameId == id && x.InstructionType == 1 && x.Instruction == 1).OrderBy(x => x.Sort).ToListAsync();
//            return Json(media);
//        }

//        [HttpPost]
//        public async Task<IActionResult> ProductRecommend()
//        {
//            var recommend =_service.GetAll<Game>().OrderBy(x => Guid.NewGuid());

//            var pic = _service.GetAll<GameMedium>().Where(x=>x.InstructionType == 2 && x.Instruction == 1);

//            var result =await recommend.Join(pic, r => r.GameId, p => p.GameId, (r, p) => new { r.GameId,r.GameName, r.GamePrice, p.MediaUrl }).Take(2).ToListAsync();
//            return Json(result);


//        }

//        public IActionResult ShoppingCart()
//        {
//            //var Ecpay = new EcpayService();
//            //var EcpayWeb = Ecpay.CreateOrder();
//            return View();
//            //return View(EcpayWeb);
//        }

//        //public async Task<IActionResult> ProductJson()
//        //{ 
            
//        //}
//    }
//}
