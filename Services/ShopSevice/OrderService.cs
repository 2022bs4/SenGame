using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
using SqlModels.Models;
using SqlModels.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ShopSevice
{
    public class OrderService : BaseService, IShopServices
    {
        public OrderService(IRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }


        public string SureOrder(string gameId, string userId)
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

            var orderId = Repository.FindBy<Order>(x => x.UserId == userId && x.OrderStatus == 1).Select(x => x.OrderId).FirstOrDefault();
            foreach (var item in array)
            {
                var game = Repository.FindBy<Game>(x => x.GameId == Int64.Parse(item)).FirstOrDefault();
                CreatDetails(orderId, game.GameId, game.GamePrice);
            };
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
            var order = await Repository.FindBy<Order>(x => x.UserId == userId && x.OrderStatus == 1).FirstOrDefaultAsync();

            order.UpdateTime = DateTime.Now;
            order.CancelTime = DateTime.Now;
            order.OrderStatus = 6;
            Repository.Update<Order>(order);
            Repository.SaveChanges();
            return "已取消所有待付款商品";
        }

    }
}
