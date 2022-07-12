using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.DTOModels.Shop
{
    public class EcpayDTO
    {
        //特店交易編號
        [StringLength(20)]
        public string MerchantTradeNo { get; set; }

        //特店交易時間 yyyy/MM/dd HH:mm:ss
        [DataType(DataType.DateTime)]
        public DateTime MerchantTradeDate { get; set; }

        //交易金額
        public decimal TotalAmount { get; set; }

        //交易敘述
        public string TradeDesc { get; set; }

        //商品名稱
        public string ItemName { get; set; }

        //允許繳費有效天數
        public int ExpireDate { get; set; }

        //綠界傳回付款資訊至此URL
        [Url]
        public string ReturnURL { get; set; }

        //使用者於綠界付款完成後，綠界將會轉只至此URL
        [Url]
        public string OrderResultURL { get; set; }

        //交易類型
        public string PaymentType { get; set; }

        //選擇預設付款方式
        public string ChoosePayment { get; set; }

        //加密類型
        public int EncryptType { get; set; }
    }
}
