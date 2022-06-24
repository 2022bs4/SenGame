using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class GameDiscount
    {
        public int DiscountId { get; set; }
        public double DiscountTake { get; set; }
        public DateTime? StarTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
