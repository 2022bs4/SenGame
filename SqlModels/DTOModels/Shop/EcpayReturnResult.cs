using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ShopSevice
{
    public class EcpayReturnResult
    {
        //RtnCode 1.付款成功 ,其餘異常
        public int RtnCode { get; set; }
        
        //交易訊息
        public string RtnMsg { get; set; }
        
        //綠界交易編號
        public string TradeNo { get; set; }

        //金額
        public int TradeAmt { get; set; }

        //訂單時間
        public string TradeDate { get; set; }

        //檢查碼
        public  string CheckMacValue { get; set; }
    }
}
