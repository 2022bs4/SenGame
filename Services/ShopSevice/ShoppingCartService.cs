using Microsoft.EntityFrameworkCore;
using SqlModels.DTOModels;
using SqlModels.Models;
using SqlModels.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ShopSevice
{
    public class ShopCartServices : BaseService
    {
        public ShopCartServices(IRepository repository) : base(repository)
        {
        }

        public async Task<List<ShoppingCartDTO>> GetShoppingCarts(string UserId)
        {
            var game = await Repository.FindBy<ShoppingCart>(x => x.UserId == UserId).ToListAsync();

            var result = new List<ShoppingCartDTO>();

            //foreach (var item in game)
            //{
            //    var picture = _gameMedium.GetAll().Where(x => x.GameId == item.GameId && x.InstructionType == 2 && x.Instruction == 1);
            //    var gameInformation = _game.GetById(item.GameId);
            //    foreach (var pic in picture)
            //    {
            //        result.Add(new ShoppingCartDTO
            //        {
            //            UserId = UserId,
            //            GameId = gameInformation.GameId,
            //            GameName = gameInformation.GameName,
            //            GameUrl = pic.MediaUrl,
            //            GamePrice = gameInformation.GamePrice,
            //            Created = item.AddTime,
            //        });
            //    }

            //}
            return result;
        }

        //public string AddShopingCart(int gameId, string UserID)
        //{
        //    var gmae = _game.GetById(gameId);
        //    var result = new ShoppingCart()
        //    {
        //        GameId = gameId,
        //        UserId = UserID,
        //        AddTime = DateTime.UtcNow,
        //    };
        //    var IsNull = _shoppingCart.GetAll().Where(x => x.GameId == result.GameId && x.UserId == result.UserId).FirstOrDefault();

        //    if (IsNull == null)
        //    {
        //        _shoppingCart.Create(result);
        //        _shoppingCart.SaveChanges();
        //        return "已幫您新增至購物車";
        //    }

        //    if (IsNull.GameId == result.GameId)
        //    {
        //        string answer = "您已加入購物車 !";
        //        return answer;
        //    }
        //    else
        //    {
        //        _shoppingCart.Create(result);
        //        _shoppingCart.SaveChanges();
        //        return "已幫您新增至購物車";
        //    }
        //}

        //public void RemveShoppingCartItem(int GameId, string UserId)
        //{

        //    var cart = _shoppingCart.GetAll().Where(x => x.UserId == UserId && x.GameId == GameId);
        //    foreach (var item in cart)
        //    {
        //        _shoppingCart.Delete(item);
        //    }
        //    _shoppingCart.SaveChanges();
        //}

        //public void RemoveAllItem(string UserId)
        //{
        //    var result = _shoppingCart.GetAll().Where(x => x.UserId == UserId).ToList();
        //    foreach (var item in result)
        //    {
        //        _shoppingCart.Delete(item);
        //    }
        //    _shoppingCart.SaveChanges();
        //}

    }
}
