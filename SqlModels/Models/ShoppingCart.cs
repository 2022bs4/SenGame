using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public int? GameId { get; set; }
        public int? UserId { get; set; }
        public DateTime? AddTime { get; set; }

        public virtual Game Game { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
