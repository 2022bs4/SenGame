using Microsoft.AspNetCore.Mvc;
using Services;
using Services.ShopSevice;
using SqlModels.ViewModels;
using SqlModels.ViewModels.ShopViewModels;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace SenGame.Controllers
{
    public class ShopController : Controller
    {
        private readonly ShopServices _services;
        private readonly ShopCartServices _ShopCartServices;
        public ShopController(ShopServices service, ShopCartServices ShopCartServices)
        {
            _services = service;
            _ShopCartServices = ShopCartServices;
        }

        //產品詳細
        public IActionResult ProductDetails(int id)
        {
            var DtoData = _services.ProductView(id);

            var result = new List<ProductDetailsViewModel>();
            foreach (var item in DtoData)
            {
                result.Add(new ProductDetailsViewModel
                {
                    GameId = item.GameId,
                    GameName = item.GameName,
                    GamePrice = item.GamePrice,
                    GameIntroduction = item.GameIntroduction,
                    ReleaseTime = item.ReleaseTime,
                    Developer = item.Developer,
                    Marker = item.Marker,
                    ProductMainPicture = item.ProductMainPicture,
                    TypleName = item.TypleName,
                    DisscountTake = item.DisscountTake,
                });
            }
            TempData["actiontype"] = "shop";
            return View(result);
        }
        public IActionResult ProductMain(int id)
        {
            var result = _services.ProductMainText(id);
            return Ok(result);
        }
        //Json
        [HttpPost]
        public IActionResult ProductDetailsJson(int id)
        {
            var result = _services.ProductSwipper(id);
            TempData["actiontype"] = "shop";
            return Json(result);
        }

        public IActionResult ProductSwipper(int id)
        {
            var result = _services.ProductSwipper(id);
            return Ok(result);
        }

        public IActionResult ProductSystem(int id)
        {
            var result = _services.ProductSystem(id);
            return Ok(result);
        }


        //遊戲購物車
        public IActionResult ShoppingCart() 
        {
            string UserId = "39f0f114-e6e0-4eb1-b3a0-2df9fd4b413c";
            // UserId = User.Identity.GetUserId();

            var shoppingCartInformation = _ShopCartServices.GetShoppingCarts(UserId);

            var result = new List<ShoppingCartViewModel>();

            foreach (var item in shoppingCartInformation)
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

            return View(result);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveShoppingItem(int GameId, string UserId)
        {
            _ShopCartServices.RemveShoppingCartItem(GameId, UserId);
            return RedirectToAction(nameof(ShoppingCart));
        }


        [HttpPost]
        //fetch防跨網站偽造要求研究中
        //[ValidateAntiForgeryToken]
        public IActionResult AddShoppingCart([FromBody] ShoppingCartViewModel model)
        {
            string UserId = "39f0f114-e6e0-4eb1-b3a0-2df9fd4b413c";
            // UserId = User.Identity.GetUserId();
            var GameId = model.GameId;
            _ShopCartServices.AddShopingCart(GameId, UserId);
            return Ok();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult DeleteAll() 
        {
            string UserId = "39f0f114-e6e0-4eb1-b3a0-2df9fd4b413c";
            // UserId = User.Identity.GetUserId();
            _ShopCartServices.RemoveAllItem(UserId);

            //return RedirectToAction(nameof(ShoppingCart));
            return View("ShoppingCart");
        }

        public IActionResult ProductRecommend()
        {
            var result = _services.ProductRecommend();
            return Ok(result);
        }

    }
}
