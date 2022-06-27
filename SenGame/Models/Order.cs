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
            Users = new HashSet<User>();
        }

        public int OrderId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderStatus { get; set; }
        public int EcpayId { get; set; }
        public string Invoice { get; set; }
        public string InvoiceWay { get; set; }

        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
