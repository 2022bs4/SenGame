using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class PurchaseDatum
    {
        public PurchaseDatum()
        {
            Games = new HashSet<Game>();
        }

        public int PurchaseDataId { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
