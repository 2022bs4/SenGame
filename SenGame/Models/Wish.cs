using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class Wish
    {
        public int WishId { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public DateTime? AddDate { get; set; }

        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}
