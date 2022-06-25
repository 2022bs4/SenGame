using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public int? GameId { get; set; }
        public int? UsrId { get; set; }
    }
}
