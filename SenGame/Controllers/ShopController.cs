using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        private readonly BuyService _BuyService;

        public ShopController(ShopServices shop, ShopCartServices shoppingCart , UserManager<UserModel> manger, BuyService buyService)
        {
            _Shop = shop;
            _ShoppingCart = shoppingCart;
            _manger = manger;
            _BuyService = buyService;
        }



        //產品詳細
        public IActionResult ProductDetails(int id )
        {
            var game = _Shop.ProductView(id);

            var result = new ProductDetailsViewModel()
            {
                GameId = game.GameId,
                GameName = game.GameName,
                GamePrice = game.GamePrice,
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
        public async Task<IActionResult> ProductMain(int id)
        {
            var result = await _Shop.ProductMainText(id);
            return Ok(result);
        }

        public async Task<IActionResult> ProductSwipper(int id)
        {
            var result = await _Shop.ProductSwipper(id);
            return Ok(result);
        }

        public async Task<IActionResult> ProductSystem(int id)
        {
            var result =await  _Shop.ProductSystem(id);
            return Ok(result);
        }


        //遊戲購物車
        public async Task<IActionResult> ShoppingCart()
        {
            UserModel user = await _manger.GetUserAsync(HttpContext.User);
            var userId = user.Id;

            var shoppingCart = await _ShoppingCart.GetShoppingCarts(userId);

            var result = new List<ShoppingCartViewModel>();

            foreach (var item in shoppingCart)
            {
                result.Add(new ShoppingCartViewModel
                {
                    UserId = item.UserId,
                    GameId = item.GameId,
                    GameName = item.GameName,
                    GamePrice = item.GamePrice,
                    GameUrl = item.GameUrl,
                    Created = item.Created,
                });
            }
            TempData["actiontype"] = "shop";
            return View(result);
        }

        [HttpPost]
        //fetch防跨網站偽造要求研究中
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddShoppingCart([FromBody] OutputShoppingCart model)
        {

            UserModel user = await _manger.GetUserAsync(HttpContext.User);
            var userId = user.Id;


            var GameId = model.GameId;
            var result =await _ShoppingCart.AddShopingCart(GameId, userId);

            var answer = new ShoppingCartViewModel(){GameId = model.GameId ,Success =result };

            return Json(answer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveShoppingItem(int GameId)
        {
            UserModel user = await _manger.GetUserAsync(HttpContext.User);
            var userId = user.Id;

            _ShoppingCart.RemveShoppingCartItem(GameId, userId);
            return RedirectToAction(nameof(ShoppingCart));
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAll()
        {
            UserModel user = await _manger.GetUserAsync(HttpContext.User);
            var userId = user.Id;

            _ShoppingCart.RemoveAllItem(userId);

            return View("ShoppingCart");
        }

        public async Task<IActionResult> ProductRecommend()
        {
            var result = await _Shop.ProductRecommend();
            return Ok(result);
        }


        //[HttpPost]
        //public async Task<IActionResult> AddOrderDetails([FromBody] OutputShoppingCart model)
        //{
        //    var gameId = model.SelectId;
        //    UserModel user = await _manger.GetUserAsync(HttpContext.User);
        //    var userId = user.Id;
        //    _BuyService.AddCarts(gameId,userId);
        //    return Ok();
        //}


        public async Task<IActionResult> CheckBuy()
        {
            UserModel user = await _manger.GetUserAsync(HttpContext.User);
            var userId = user.Id;
            var gameInformation = await _BuyService.GetCheckItem(userId);
            var result = new List<CheckBuyViewModel>();

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
}
