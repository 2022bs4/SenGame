using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Interface;
using SqlModels.Models;
using SqlModels.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SenGame.Service
{
    public class EcpayService :BaseService, IShopServices
    {
        public EcpayService(IRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<Dictionary<string,string>> GetPayInformation(string userId)
        {
            var userOrder = await Repository.FindBy<Order>(x => x.UserId == userId && x.OrderStatus == 1).FirstOrDefaultAsync();
            //var orderGame = await Repository.FindBy<Orderdetail>(x => x.OrderId == userOrder.OrderId).Select(x => x.GameId).;
            
            var CheckMacValue  = EcpayInformation(userOrder.TotalPrice,"測試");
            return CheckMacValue;
        }

        public Dictionary<string,string> EcpayInformation(decimal totalPrice, string tradeDetails)
        {
            var orderId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 20);
            var website = $"https://localhost:44316";

            var order = new Dictionary<string, string>
            {
                { "MerchantID",  "2000132"},
                { "IgnorePayment", "GooglePay#WebATM#CVS#BARCODE"},
                { "PaymentType",  "aio"},
                { "ChoosePayment",  "ALL"},
                { "EncryptType",  "1"},
            };
            order.Add("MerchantTradeNo", orderId);
            order.Add("MerchantTradeDate", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            order.Add("TotalAmount", $"{(int)totalPrice}");
            order.Add("TradeDesc", "SenGame遊戲平台");
            order.Add("ItemName", $"{tradeDetails}");
            order.Add("ExpireDate", "1");
            order.Add("ReturnURL", $"https://localhost:44316/api/Shop/ReturnResult");
            order.Add("OrderResultURL", $"{website}/Home/Index");
            order.Add("CheckMacValue", $"{GetCheckMacValue(order)}");
            return order;
        }
        private string GetCheckMacValue(Dictionary<string, string> order)
        {
            var param = order.Keys.OrderBy(x => x).Select(key => key + "=" + order[key]).ToList();
            var checkValue = string.Join("&", param);
            var hashKey = "5294y06JbISpM5x9";
            var HashIV = "v77hoKGq4kWxNNIS";
            checkValue = $"HashKey={hashKey}" + "&" + checkValue + "&" + $"HashIV={HashIV}";
            checkValue = HttpUtility.UrlEncode(checkValue).ToLower();
            checkValue = GetSHA256(checkValue);
            return checkValue.ToUpper();
        }
        private string GetSHA256(string value)
        {
            var result = new StringBuilder();

            var sha256 = SHA256Managed.Create();

            var bts = Encoding.UTF8.GetBytes(value);

            var hash = sha256.ComputeHash(bts);

            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }

            return result.ToString();
        }
    }
}
