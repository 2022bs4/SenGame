using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SenGame.Service;
using Services;
using Services.ShopSevice;
using SqlModels.Models;
using SqlModels.ViewModels;
using SqlModels.ViewModels.ShopViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SenGame.Controllers
{
    public class ShopController : Controller
    {
        private readonly ShopServices _Shop;
        private readonly ShopCartServices _ShoppingCart;
        private readonly UserManager<UserModel> _manger;
        private readonly EcpayService _Ecpay;
        public ShopController(ShopServices shop, ShopCartServices shoppingCart, UserManager<UserModel> manger, EcpayService ecpay)
        {
            _Shop = shop;
            _ShoppingCart = shoppingCart;
            _manger = manger;
            _Ecpay = ecpay;
        }
        public  IActionResult Index()
        {
            return View("Game");
        }
        //產品詳細
        public async Task<IActionResult> ProductDetails(int id)
        {
            var game = await _Shop.ProductView(id);

            var result = new ProductDetailsVM()
            {
                ProductItem = new ProductDetailsVM.ProductInformation
                {
                    GameId = game.GameId,
                    GameName = game.GameName,
                    GamePrice = game.GamePrice,
                    GameIntroduction = game.GameIntroduction,
                    ReleaseTime = game.ReleaseTime,
                    Developer = game.Developer,
                    Marker = game.Marker,
                    GamePicture = game.GamePicture,
                },
                DisscountTake = game.DisscountTake,
                GameTyple = game.GameTyple.Select(item => new ProductDetailsVM.TypleData
                {
                    GameId = item.GameId,
                    TypleName = item.TypleName
                }).ToList(),
            };
            TempData["Title"] = "Shop";
            return View(result);
        }
        
        //遊戲購物車
        public async Task<IActionResult> ShoppingCart()
        {
            var userId = await GetUserId();

            var shoppingCart = await _ShoppingCart.GetShoppingCarts(userId);

            var result = new List<InputShoppingCartVM>();

            foreach (var item in shoppingCart)
            {
                result.Add(new InputShoppingCartVM
                {
                    UserId = item.UserId,
                    GameId = item.GameId,
                    GameName = item.GameName,
                    GamePrice = (int)item.GamePrice,
                    GameUrl = item.GameUrl,
                    Created = item.Date,
                });
            }
            TempData["actiontype"] = "shop";
            return View(result);
        }

        public async Task<IActionResult> CheckBuy()
        {
            var userId = await GetUserId();
            var gameInformation = await _ShoppingCart.GetCheckItem(userId);
            var result = new List<InputCheckBuyVM>();
            if (gameInformation == null)
            {
                return View();
            }
            else
            {
                foreach (var item in gameInformation)
                {
                    result.Add(new InputCheckBuyVM
                    {
                        UserId = item.UserId,
                        GameId = item.GameId,
                        GameName = item.GameName,
                        GamePrice = item.GamePrice,
                        GameUrl = item.GameUrl,
                    });
                }
                return View(result);
            }
        }


        //綠界付款回傳資訊
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult Index([FromForm] EcpayReturnResult data)
        {
            var result = data.RtnCode;
            //交易是否成功
            ViewBag["result"] = result;
            return View("CheckBuy");
        }

        public async Task<string> GetUserId()
        {
            UserModel user = await _manger.GetUserAsync(HttpContext.User);
            var userId = user.Id;
            return userId;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveShoppingItem(int GameId)
        {
            var userId = await GetUserId();

            _ShoppingCart.RemveShoppingCartItem(GameId, userId);
            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}
