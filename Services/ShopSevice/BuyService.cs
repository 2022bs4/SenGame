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
    public class BuyService : BaseService
    {
        public BuyService(IRepository repository,IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<List<CheckBuyDTO>> GetCheckItem(string userId)
        {

            var orderId = await Repository.FindBy<Order>(x => x.UserId == userId).FirstOrDefaultAsync();
            var orderDetails = await Repository.FindBy<Orderdetail>(x => x.OrderId == orderId.OrderId).Select(x => x.GameId).ToListAsync();

            var result = new List<CheckBuyDTO>();

            foreach (var item in orderDetails)
            {
                var pic = await Repository.FindBy<GameMedium>(x => x.GameId == item && x.InstructionType == 2 && x.Instruction == 1).ToListAsync();
                var game = await Repository.FindBy<Game>(x => x.GameId == item).FirstAsync();
                foreach (var i in pic)
                {
                    result.Add(new CheckBuyDTO
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
            if (selectUserId.Count() == 0)
            {
                foreach (var item in array)
                {
                    var game = Repository.FindBy<Game>(x => x.GameId == Int64.Parse(item)).FirstOrDefault();
                    totalPrice += game.GamePrice;
                };
                CreatOrder(userId, totalPrice);
            }
            else if (selectUserId.Any(x=>x.OrderStatus != 1))
            {
                CreatOrder(userId, totalPrice);
            }
            else
            {
                return "您尚有商品未結帳";
            }

            var orderId = Repository.FindBy<Order>(x => x.UserId == userId).Select(x => x.OrderId).FirstOrDefault();
            foreach (var item in array)
            {
                var game = Repository.FindBy<Game>(x => x.GameId == Int64.Parse(item)).FirstOrDefault();
                CreatDetails(orderId, game.GameId, game.GamePrice);
            };
            return "請至結帳畫面結帳付款";
        }
  
        public  void CreatOrder(string userId ,decimal totalPrice)
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

        public  void CreatDetails(int orderId ,int gameId , decimal price)
        {
            var details = new Orderdetail()
            {
                OrderId = orderId,
                GameId = gameId,
                Price = price,
            };
             Create<Orderdetail>(details);
        }


        //尚未Updata
        public async Task<string> RemoveCheckBuy(string userId)
        {
            var order = await Repository.FindBy<Order>(x => x.UserId == userId).FirstOrDefaultAsync();



            return "已取消所有待付款商品";
        }

        
    }
}
