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
        public BuyService(IRepository repository) : base(repository)
        {
        }

        public async Task<List<CheckBuyDTO>> GetCheckItem(string userId)
        {

            var orderId = await Repository.FindBy<UserModel>(x => x.Id == userId).FirstOrDefaultAsync();
            var order = await Repository.FindBy<Order>(x => x.OrderId == orderId.OrderId).FirstOrDefaultAsync();
            var orderDetails = await Repository.FindBy<Orderdetail>(x => x.OrderId == order.OrderId).Select(x => x.GameId).ToListAsync();

            var result = new List<CheckBuyDTO>();

            foreach (var item in orderDetails)
            {
                var pic = await Repository.FindBy<GameMedium>(x => x.GameId == item && x.InstructionType == 2 && x.Instruction == 1).ToListAsync();
                var game = await Repository.FindBy<Game>(x => x.GameId == item).FirstAsync();
                foreach (var i in pic)
                {
                    result.Add(new CheckBuyDTO {
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
        //public async void AddCarts(string gameId, string userId)
        //{
        //    CreatCart(userId);

        //    var orderId = Repository.FindBy



        //    var array = gameId.Split(',');
        //    int[] newarray = new int[] { };
        //    foreach (var item in array)
        //    {
        //        var gmaeId = Int64.Parse(item);
        //        var game = await Repository.FindBy<Game>(x => x.GameId == gmaeId).FirstOrDefaultAsync();

        //    };

        //}

        //public void CreatCart(string userId)
        //{
        //    var creatOrder = new Order()
        //    {
        //        CreateTime = DateTime.Now,
        //        OrderStatus = 1,
        //    };
        //    Create<Order>(creatOrder);

        //    var setUserOrderId = Repository.FindBy<UserModel>(x => x.Id == userId).FirstOrDefault();

            

        //    //var result = new UserModel
        //    //{
        //    //    Id = userId,
        //    //    OrderId = 
        //    //};

        //    Update<UserModel>(result);
        //}

    }
}
