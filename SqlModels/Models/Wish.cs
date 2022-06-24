using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class Wish
    {
        public int WishId { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public DateTime? AddTime { get; set; }
    }
}
