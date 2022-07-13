using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SenGame.Service;
using Services;
using Services.ShopSevice;
using SqlModels.Models;
using SqlModels.ViewModels.ShopViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SenGame.ApiController
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class ShopController : ControllerBase
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

        //[EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<IActionResult> ProductSwipper(int id)
        {
            var result = await _Shop.ProductSwipper(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> ProductMain(int id)
        {
            var result = await _Shop.ProductMainText(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> ProductSystem(int id)
        {
            var result = await _Shop.ProductSystem(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> ProductRecommend()
        {
            var result = await _Shop.ProductRecommend();
            return Ok(result);
        }

        [HttpPost]
        //fetch防跨網站偽造要求研究中
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddShoppingCart([FromBody] OutputShoppingCart model)
        {
            var userId = await GetUserId();
            var GameId = model.GameId;
            var result = await _ShoppingCart.AddShopingCart(GameId, userId);
            var answer = new ShoppingCartViewModel() { GameId = model.GameId, Success = result };
            return Ok(answer);
        }



        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAll()
        {
            var userId = await GetUserId();
            _ShoppingCart.RemoveAllItem(userId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderDetails([FromBody] OutputShoppingCart model)
        {
            var gameId = model.SelectId;
            var userId = await GetUserId();
            var result = _ShoppingCart.AddCarts(gameId, userId);
            return Ok(result);
        }




        [HttpGet]
        public async Task<IActionResult> Payment()
        {
            var userId = await GetUserId();
            var result = await _Ecpay.GetPayInformation(userId);
            return Ok(result);
        }






        //尚未完成
        [HttpPost]
        public async Task<IActionResult> RemoveCheckBuy()
        {
            var userId = await GetUserId();
            var result = await _ShoppingCart.RemoveCheckBuy(userId);
            return Ok(result);
        }






        //跨域問題尚未解決
        [HttpPost]
        public HttpResponseMessage ReturnResult([FromBody] Dictionary<string, string> data)
        {

            return ResponseOK();
        }

        private HttpResponseMessage ResponseOK()
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent("1|OK");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }




        
        public async Task<string> GetUserId()
        {
            UserModel user = await _manger.GetUserAsync(HttpContext.User);
            var userId = user.Id;
            return userId;
        }
    }
}
