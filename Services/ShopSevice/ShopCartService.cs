using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
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
    public class ShopCartServices : BaseService, IShopServices
    {
        public class ClinetResponse
        {
            public bool Success { get; set; }
            public int Code { get; set; }
            public object Response { get; set; }
            public string Msg { get; set; }
        }
        public ShopCartServices(IRepository repository,IMapper mapper) : base(repository, mapper)
        {
        }

       


        public async Task<List<ResponseProductItem>> GetShoppingCarts(string UserId)
        {
            var shoppingCarts = await Repository.FindBy<ShoppingCart>(x => x.UserId == UserId).ToListAsync();

            var result = new List<ResponseProductItem>();

            foreach (var item in shoppingCarts)
            {
                var pic = await FindBy<GameMedium>(x => x.GameId == item.GameId && x.InstructionType == 2 && x.Instruction == 1).ToListAsync();
                var game = await Repository.FindBy<Game>(x=>x.GameId == item.GameId).FirstOrDefaultAsync();
                foreach (var picItem in pic)
                {
                    result.Add(new ResponseProductItem
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
        }


        public async Task<List<ResponseProductItem>> GetCheckItem(string userId)
        {

            var orderId = await Repository.FindBy<Order>(x => x.UserId == userId  && x.OrderStatus==1).FirstOrDefaultAsync();
            if (orderId == null)
            {   
                return null;
            }
            var orderDetails = await Repository.FindBy<Orderdetail>(x => x.OrderId == orderId.OrderId).Select(x => x.GameId).ToListAsync();

            var result = new List<ResponseProductItem>();

            foreach (var item in orderDetails)
            {
                var pic = await Repository.FindBy<GameMedium>(x => x.GameId == item && x.InstructionType == 2 && x.Instruction == 1).ToListAsync();
                var game = await Repository.FindBy<Game>(x => x.GameId == item).FirstAsync();
                foreach (var i in pic)
                {
                    result.Add(new ResponseProductItem
                    {
                        UserId = userId,
                        GameId = game.GameId,
                        GameName = game.GameName,
                        GameUrl = i.MediaUrl,
                        GamePrice = game.GamePrice,
                    });
                }
            }
            return result;
        }

        public string AddCarts(string gameId, string userId)
        {
            var selectUserId = Repository.FindBy<Order>(x => x.UserId == userId);

            var array = gameId.Split(',');
            decimal totalPrice = 0;
            if (selectUserId.Count() == 0 || selectUserId.Any(x => x.OrderStatus != 1))
            {
                foreach (var item in array)
                {
                    var game = Repository.FindBy<Game>(x => x.GameId == Int64.Parse(item)).FirstOrDefault();
                    totalPrice += game.GamePrice;
                };
                CreatOrder(userId, totalPrice);
            }
            else
            {
                return "您尚有商品未結帳";
            }

            var orderId = Repository.FindBy<Order>(x => x.UserId == userId && x.OrderStatus==1).Select(x => x.OrderId).FirstOrDefault();
            foreach (var item in array)
            {
                var game = Repository.FindBy<Game>(x => x.GameId == Int64.Parse(item)).FirstOrDefault();
                CreatDetails(orderId, game.GameId, game.GamePrice);
            };

            RemoveAllItem(userId);

            return "請至結帳畫面結帳付款";
        }

        public void CreatOrder(string userId, decimal totalPrice)
        {
            var creatOrder = new Order()
            {
                CreateTime = DateTime.Now,
                OrderStatus = 1,
                UserId = userId,
                TotalPrice = totalPrice,
            };
            Create<Order>(creatOrder);
        }

        public void CreatDetails(int orderId, int gameId, decimal price)
        {
            var details = new Orderdetail()
            {
                OrderId = orderId,
                GameId = gameId,
                Price = price,
            };
            Create<Orderdetail>(details);
        }


        public async Task<string> RemoveCheckBuy(string userId)
        {
            var order = await Repository.FindBy<Order>(x => x.UserId == userId && x.OrderStatus ==1).FirstOrDefaultAsync();

            order.UpdateTime = DateTime.Now;
            order.CancelTime = DateTime.Now;
            order.OrderStatus = 6;
            Repository.Update<Order>(order);
            Repository.SaveChanges();
            return "已取消所有待付款商品";
        }
    }
}
