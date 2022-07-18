using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public int? GameId { get; set; }
        public string UserId { get; set; }
        public DateTime? AddTime { get; set; }

        public virtual Game Game { get; set; }
        public virtual UserModel User { get; set; }
    }
}
