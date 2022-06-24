using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderStatus { get; set; }
        public int EcpayId { get; set; }
        public string Invoice { get; set; }
        public string InvoiceWay { get; set; }
    }
}
