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
        public IActionResult Index()
        {
            var product = _Shop.ProductIndex();

            return View("Game");
        }
        //產品詳細
        public IActionResult ProductDetails(int id)
        {
            var game = _Shop.ProductView(id);

            var result = new ProductDetailsViewModel()
            {
                GameId = game.GameId,
                GameName = game.GameName,
                GamePrice = (int)game.GamePrice,
                GameIntroduction = game.GameIntroduction,
                ReleaseTime = game.ReleaseTime,
                Developer = game.Developer,
                Marker = game.Marker,
                DisscountTake = game.DisscountTake,
                GamePicture = game.GamePicture,
                GameTyple = game.GameTyple.Select(item => new ProductDetailsViewModel.TypleData
                {
                    GameId = item.GameId,
                    TypleName = item.TypleName
                }),
            };
            TempData["Title"] = "Shop";
            return View(result);
        }
        
        //遊戲購物車
        public async Task<IActionResult> ShoppingCart()
        {
            var userId = await GetUserId();

            var shoppingCart = await _ShoppingCart.GetShoppingCarts(userId);

            var result = new List<ShoppingCartViewModel>();

            foreach (var item in shoppingCart)
            {
                result.Add(new ShoppingCartViewModel
                {
                    UserId = item.UserId,
                    GameId = item.GameId,
                    GameName = item.GameName,
                    GamePrice = (int)item.GamePrice,
                    GameUrl = item.GameUrl,
                    Created = item.Created,
                });
            }
            TempData["actiontype"] = "shop";
            return View(result);
        }

        public async Task<IActionResult> CheckBuy()
        {
            var userId = await GetUserId();
            var gameInformation = await _ShoppingCart.GetCheckItem(userId);
            var result = new List<CheckBuyViewModel>();
            if (gameInformation == null)
            {
                //return RedirectToRoute(new { controller = "Game", action = "Game" });
                return View();
            }
            else
            {
                foreach (var item in gameInformation)
                {
                    result.Add(new CheckBuyViewModel
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
