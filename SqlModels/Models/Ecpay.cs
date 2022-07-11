using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class Ecpay
    {
        public string MerchantId { get; set; }
        public string ReturnUrl { get; set; }
        public int ChoosePayment { get; set; }
        public string ClientBackUrl { get; set; }
        public int ExpireDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public string HashKey { get; set; }
        public string HashIv { get; set; }
    }
}
