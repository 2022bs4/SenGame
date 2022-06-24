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
        public double DiscountTake { get; set; }
        public DateTime? StarTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public static implicit operator GameDiscount(int v)
        {
            throw new NotImplementedException();
        }
    }
}
