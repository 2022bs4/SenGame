using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class Order
    {
        public Order()
        {
            //AspNetUsers = new HashSet<UserModel>();
            Orderdetails = new HashSet<Orderdetail>();
        }

        public int OrderId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? TradeTime { get; set; }
        public DateTime? CancelTime { get; set; }
        public decimal? TotalPrice { get; set; }
        public int OrderStatus { get; set; }
        public string EcpayId { get; set; }
        public string Invoice { get; set; }
        public string InvoiceWay { get; set; }

        //
        public string UserId { get; set; }

        //
        public virtual UserModel User { get; set; }
        //public virtual ICollection<UserModel> AspNetUsers { get; set; }
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
    }
}
