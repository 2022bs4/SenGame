using AutoMapper;
using Services;
using SqlModels.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SenGame.Service
{
    public class EcpayService :BaseService
    {
        public EcpayService(IRepository repository,IMapper mapper) : base(repository,mapper)
        {
        }

        public async void GetPayInformation()
        {

        }

        public string CreateOrder()
        {
            var orderId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 20);
            var website = $"https://localhost:44398";

            var order = new Dictionary<string, string>
            {
                //特店交易編號
                { "MerchantTradeNo",  orderId},

                //特店交易時間 yyyy/MM/dd HH:mm:ss
                {"MerchantTradeDate",DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") },

                //交易金額
                {"TotalAmount","4000" },

                //交易敘述
                {"TradeDesc","SenGame測試商品" },

                //商品名稱
                {"ItemName","SenGame測試商品" },

                //允許繳費有效天數
                {"ExpireDate","3" },

                //綠界傳回付款資訊至此URL
                {"ReturnURL", $"{website}/api/Game/AddPayInfo"},

                //使用者於綠界付款完成後，綠界將會轉只至此URL
                //{"OrderResultURL",$"{website}/Ecpay/PayInfo/{orderId}" },

                //特店編號， 2000132 測試綠界編號
                { "MerchantID",  "2000132"},

                //忽略付款方式
                { "IgnorePayment", "GooglePay#WebATM#CVS#BARCODE"},

                //交易類型 固定填入 aio
                { "PaymentType",  "aio"},

                //選擇預設付款方式 固定填入 ALL
                { "ChoosePayment",  "ALL"},

                //CheckMacValue 加密類型 固定填入 1 (SHA256)
                { "EncryptType",  "1"},
            };
            //檢查碼
            return order["CheckMacValue"] = GetCheckMacValue(order);
        }
        private string GetCheckMacValue(Dictionary<string, string> order)
        {
            var param = order.Keys.OrderBy(x => x).Select(key => key + "=" + order[key]).ToList();
            var checkValue = string.Join("&", param);

            //測試用的 HashKey
            var hashKey = "5294y06JbISpM5x9";

            //測試用的 HashIV
            var HashIV = "v77hoKGq4kWxNNIS";

            //將hashKey HashIV 插入再param前後，形成  HashK=hashKey&HashIV=paramHashIV
            checkValue = $"HashKey={hashKey}" + "&" + checkValue + "&" + $"HashIV={HashIV}";

            //UrlEncode(String)	將 URL 字串編碼 ，並轉為小寫
            checkValue = HttpUtility.UrlEncode(checkValue).ToLower();

            //用方法雜湊
            checkValue = GetSHA256(checkValue);

            return checkValue.ToUpper();
        }

        /// SHA256 編碼
        private string GetSHA256(string value)
        {
            //表示可變動的字元字串。 此類別無法獲得繼承
            var result = new StringBuilder();

            //SHA256Managed
            var sha256 = SHA256Managed.Create();

            //GetBytes(String)在衍生類別中覆寫時，將指定字串中的所有字元編碼成位元組序列
            var bts = Encoding.UTF8.GetBytes(value);

            //計算指定位元組陣列的雜湊值
            var hash = sha256.ComputeHash(bts);

            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }

            return result.ToString();
        }
    }
}
