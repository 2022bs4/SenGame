using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class Order
    {
        public Order()
        {
            Orderdetails = new HashSet<Orderdetail>();
        }

        public int OrderId { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public int TotalPrice { get; set; }
        public int OrderStatusId { get; set; }
        public int EcpayId { get; set; }
        public string Invoice { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
    }
}
