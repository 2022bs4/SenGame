using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int OrderStatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
