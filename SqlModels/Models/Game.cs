using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class Game
    {
        public int GameId { get; set; }
        public int DiscountId { get; set; }
        public string GameName { get; set; }
        public decimal GamePrice { get; set; }
        public string GameIntroduction { get; set; }
        public string GameDetailsText { get; set; }
        public int? TotalBuyCount { get; set; }
        public DateTime ReleaseTime { get; set; }
        public DateTime? DownTime { get; set; }
        public string Developer { get; set; }
        public string Marker { get; set; }
    }
}
