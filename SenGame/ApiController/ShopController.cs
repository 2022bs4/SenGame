using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SenGame.Service;
using Services;
using Services.ShopSevice;
using SqlModels.DTOModels;
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

        //首頁Tag
        [HttpGet]
        public async Task<IActionResult> IndexTag()
        {
            var result = await _Shop.GetIndexTag();
            return Ok(result);

        }
        //首頁預設Swipper
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //首頁預設加載
            string request = "人氣最高";
            var result = await _Shop.GetIndesSwipper(request);
            return Ok(result);
        }
        //首頁上排觸發回傳
        [HttpPost]
        public async Task<IActionResult> PostIndex([FromBody] IndexProductDTO model)
        {
            var request = model.UserRequest;
            var result = await _Shop.GetIndesSwipper(request);
            return Ok(result);
        }
        //首頁預設清單
        [HttpGet]
        public async Task<IActionResult> IndexList()
        {
            var result = await _Shop.GetProductList();
            return Ok(result);
        }
        [HttpPost]
        //首頁預設清單多圖板
        public async Task<IActionResult> IndexListDetails([FromBody] OutputShoppingCart model)
        {
            var gameId = model.GameId;
            var result = await _Shop.GetDetailsList(gameId);
            return Ok(result);
        }




        //商品詳細之Swipper
        [HttpGet]
        public async Task<IActionResult> ProductSwipper(int id)
        {
            var result = await _Shop.ProductSwipper(id);
            return Ok(result.SwipperData);
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
            return Ok(result.SystemData);
        }

        //遊戲推薦
        [HttpGet]
        public async Task<IActionResult> ProductRecommend()
        {
            var result = await _Shop.ProductRecommend();
            return Ok(result);
        }


        //添加至購物車，防呆已做，CROS未做
        [HttpPost]
        //fetch防跨網站偽造要求研究中
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddShoppingCart([FromBody] OutputShoppingCart model)
        {
            var userId = await GetUserId();
            var GameId = model.GameId;
            var result = await _ShoppingCart.AddShopingCart(GameId, userId);
            var answer = new InputShoppingCartVM() { GameId = model.GameId, Success = result };
            return Ok(answer);
        }


        //購物車全部刪除，之後打算重新命名
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAll()
        {
            var userId = await GetUserId();
            _ShoppingCart.RemoveAllItem(userId);
            return Ok();
        }

        //將購物車資訊添加至訂單，添加完後刪除購物車已做，若有待結帳項目直接轉至結帳已做
        [HttpPost]
        public async Task<IActionResult> AddOrderDetails([FromBody] OutputShoppingCart model)
        {
            var gameId = model.SelectId;
            var userId = await GetUserId();
            var result = _ShoppingCart.AddCarts(gameId, userId);
            return Ok(result);
        }

        //取消結帳，訂單狀態更改完取消
        [HttpPost]
        public async Task<IActionResult> RemoveCheckBuy()
        {
            var userId = await GetUserId();
            var result = await _ShoppingCart.RemoveCheckBuy(userId);
            return Ok(result);
        }


        //將訂單資訊post至ECPA
        [HttpGet]
        public async Task<IActionResult> Payment()
        {
            var userId = await GetUserId();
            var result = await _Ecpay.GetPayInformation(userId);
            return Ok(result);
        }


        //跨域問題尚未解決，目的:接收綠借回傳值且驗證購買結果
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

        //或許會員ID之後會請會員模組負責人封裝
        public async Task<string> GetUserId()
        {
            UserModel user = await _manger.GetUserAsync(HttpContext.User);
            var userId = user.Id;
            return userId;
        }
    }
}
