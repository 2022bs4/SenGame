using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class GameDiscount
    {
        public GameDiscount()
        {
            Games = new HashSet<Game>();
        }

        public int DiscountId { get; set; }
        public int? DiscountTake { get; set; }
        public DateTime? StarDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
