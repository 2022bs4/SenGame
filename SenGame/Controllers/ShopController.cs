using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
using SqlModels.Models;
using SqlModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenGame.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopServices _services;
        public ShopController(IShopServices service)
        {
            _services = service;
        }

        public IActionResult ProductDetails(int id = 1)
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
            return View(result);
        }

        public IActionResult ProductMain(int id)
        { 
            var result = _services.ProductMainText(id);
            return Ok(result);
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
        public IActionResult ProductRecommend()
        {
            var result = _services.ProductRecommend();
            return Ok(result);
        }

        public IActionResult ShoppingCart(int id=1) {

            return View();
        }
    }
}
