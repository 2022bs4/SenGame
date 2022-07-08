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
    public class ShopCartServices : BaseService<ShoppingCart>
    {
        private readonly IRepository<ShoppingCart> _shoppingCart;
        private readonly IRepository<Game> _game;
        private readonly IRepository<GameMedium> _gameMedium;

        public ShopCartServices(IRepository<ShoppingCart> repository , IRepository<Game> game , IRepository<GameMedium> gameMedium) : base(repository)
        {
            this._shoppingCart = repository;
            this._game = game;
            this._gameMedium = gameMedium;
        }
        
        public List<ShoppingCartDTO> GetShoppingCarts(string UserId)
        {
            //string UserId = "39f0f114-e6e0-4eb1-b3a0-2df9fd4b413c";
            var game = _shoppingCart.GetAll().Where(x => x.UserId == UserId);
            var result = new List<ShoppingCartDTO>();

            foreach (var item in game)
            {
                var picture = _gameMedium.GetAll().Where(x=>x.GameId==item.GameId && x.InstructionType==2&&x.Instruction==1);
                var gameInformation = _game.GetById(item.GameId);
                foreach (var pic in picture)
                {
                    result.Add(new ShoppingCartDTO
                    {
                        UserId = UserId,
                        GameId = gameInformation.GameId,
                        GameName = gameInformation.GameName,
                        GameUrl = pic.MediaUrl,
                        GamePrice = gameInformation.GamePrice,
                        Created = item.AddTime,
                    });
                }
                
            }
            return result;
        }

        public string AddShopingCart(int gameId, string UserID)
        {
            var gmae = _game.GetById(gameId);
            var result = new ShoppingCart()
            {
                GameId = gameId,
                UserId = UserID,
                AddTime = DateTime.UtcNow,
            };
            var IsNull = _shoppingCart.GetAll().Where(x => x.GameId == result.GameId && x.UserId == result.UserId).FirstOrDefault();

            if (IsNull == null)
            {
                _shoppingCart.Create(result);
                _shoppingCart.SaveChanges();
                return "已幫您新增至購物車";
            }

            if (IsNull.GameId == result.GameId)
            {
                string answer = "您已加入購物車 !";
                return answer;
            }
            else
            {
                _shoppingCart.Create(result);
                _shoppingCart.SaveChanges();
                return "已幫您新增至購物車";
        }
    }

        public void RemveShoppingCartItem(int GameId , string UserId)
        {

            var cart =_shoppingCart.GetAll().Where(x => x.UserId == UserId && x.GameId == GameId);
            foreach (var item in cart)
            {
                _shoppingCart.Delete(item);
            }
            _shoppingCart.SaveChanges();
        }

        public void RemoveAllItem(string UserId)
        {
            var result = _shoppingCart.GetAll().Where(x => x.UserId == UserId).ToList();
            foreach (var item in result)
            {
                _shoppingCart.Delete(item);
            }
                _shoppingCart.SaveChanges();
        }
    }
}
