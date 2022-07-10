using Microsoft.AspNetCore.Mvc;
using Services;
using Services.ShopSevice;
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

        public ShopController(ShopServices shop, ShopCartServices shoppingCart)
        {
            _Shop = shop;
            _ShoppingCart = shoppingCart;
        }



        //產品詳細
        public IActionResult ProductDetails(int id = 1)
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
        public IActionResult ShoppingCart()
        {
            string UserId = "39f0f114-e6e0-4eb1-b3a0-2df9fd4b413c";
            
            var shoppingCart = _ShoppingCart.GetShoppingCarts(UserId);

            //var shoppingCartInformation = _ShopCartServices.GetShoppingCarts(UserId);

            //var result = new List<ShoppingCartViewModel>();

            //foreach (var item in shoppingCartInformation)
            //{
            //    result.Add(new ShoppingCartViewModel
            //    {
            //        UserId = item.UserId,
            //        GameId = item.GameId,
            //        GameName = item.GameName,
            //        GamePrice = item.GamePrice,
            //        GameUrl = item.GameUrl,
            //        Created = item.Created,
            //    });
            //}
            //TempData["actiontype"] = "shop";
            return View();
        }

        //[HttpPost]
        ////fetch防跨網站偽造要求研究中
        ////[ValidateAntiForgeryToken]
        //public IActionResult AddShoppingCart([FromBody] ShoppingCartViewModel model)
        //{
        //    string UserId = "39f0f114-e6e0-4eb1-b3a0-2df9fd4b413c";
        //    // UserId = User.Identity.GetUserId();
        //    var GameId = model.GameId;
        //    var result = _ShopCartServices.AddShopingCart(GameId, UserId);
        //    return Content(result);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult RemoveShoppingItem(int GameId, string UserId)
        //{
        //    _ShopCartServices.RemveShoppingCartItem(GameId, UserId);
        //    return RedirectToAction(nameof(ShoppingCart));
        //}




        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //public IActionResult DeleteAll()
        //{
        //    string UserId = "39f0f114-e6e0-4eb1-b3a0-2df9fd4b413c";
        //    // UserId = User.Identity.GetUserId();
        //    _ShopCartServices.RemoveAllItem(UserId);

        //    //return RedirectToAction(nameof(ShoppingCart));
        //    return View("ShoppingCart");
        //}

        public async Task<IActionResult> ProductRecommend()
        {
            var result = await _Shop.ProductRecommend();
            return Ok(result);
        }

    }
}
