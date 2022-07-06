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
        public List<ShoppingCartDTO> ShoppingCarts(string UserId = "39f0f114-e6e0-4eb1-b3a0-2df9fd4b413c")
        {
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
        public void RemveShoppingCartItem( int GameId)
        {
            var cart =  _shoppingCart.GetById(GameId);
            _shoppingCart.Delete(cart);
            _shoppingCart.SaveChanges();
            

        }

    }
}
