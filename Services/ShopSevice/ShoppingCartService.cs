using AutoMapper;
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
        public ShopCartServices(IRepository repository,IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<List<ShoppingCartDTO>> GetShoppingCarts(string UserId)
        {
            var shoppingCarts = await Repository.FindBy<ShoppingCart>(x => x.UserId == UserId).ToListAsync();

            var result = new List<ShoppingCartDTO>();

            foreach (var item in shoppingCarts)
            {
                var pic = await FindBy<GameMedium>(x => x.GameId == item.GameId && x.InstructionType == 2 && x.Instruction == 1).ToListAsync();
                var game = await Repository.FindBy<Game>(x=>x.GameId == item.GameId).FirstOrDefaultAsync();
                foreach (var picItem in pic)
                {
                    result.Add(new ShoppingCartDTO
                    { 
                        UserId = UserId,
                        GameId = item.GameId,
                        GameName = game.GameName,
                        GamePrice = game.GamePrice,
                        Created = item.AddTime,
                        GameUrl = picItem.MediaUrl,
                    });
                }
            }

            return result;
        }

        public async Task<string> AddShopingCart(int gameId, string UserID)
        {
            var game = await Repository.FindBy<Game>(x=>x.GameId == gameId).FirstOrDefaultAsync();

            var result = new ShoppingCart()
            {
                GameId = gameId,
                UserId = UserID,
                AddTime = DateTime.UtcNow,
            };

            var IsNull = await GetAll<ShoppingCart>().Where(x => x.GameId == result.GameId && x.UserId == result.UserId).FirstOrDefaultAsync();

            if (IsNull == null)
            {
                Create<ShoppingCart>(result);

                return "已幫您新增至購物車";
            }

            if (IsNull.GameId == result.GameId)
            {
                string answer = "您已加入購物車 !";
                return answer;
            }
            else
            {
                Create<ShoppingCart>(result);;
                return "已幫您新增至購物車";
            }
        }

        public void RemveShoppingCartItem(int GameId, string UserId)
        {
            var shoppingCart = Repository.FindBy<ShoppingCart>(x => x.GameId == GameId && x.UserId == UserId).FirstOrDefault();

            Delete<ShoppingCart>(shoppingCart);
        }

        public void RemoveAllItem(string UserId)
        {
            var result = Repository.GetAll<ShoppingCart>().Where(x => x.UserId == UserId).ToList();
            foreach (var item in result)
            {
                Delete<ShoppingCart>(item);
            }
            //var result = _shoppingCart.GetAll().Where(x => x.UserId == UserId).ToList();
            //foreach (var item in result)
            //{
            //    _shoppingCart.Delete(item);
            //}
            //_shoppingCart.SaveChanges();
        }

    }
}
