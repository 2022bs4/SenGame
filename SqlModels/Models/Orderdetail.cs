using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class Orderdetail
    {
        public int OrderdetailId { get; set; }
        public int OrderId { get; set; }
        public int GameId { get; set; }
        public decimal Price { get; set; }
        public double? Discount { get; set; }

        public virtual Order Order { get; set; }
    }
}
