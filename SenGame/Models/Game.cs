using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class Game
    {
        public Game()
        {
            Articles = new HashSet<Article>();
            MyForums = new HashSet<MyForum>();
            MyGames = new HashSet<MyGame>();
            Wishes = new HashSet<Wish>();
        }

        public int GameId { get; set; }
        public int DiscountId { get; set; }
        public int GameTypleId { get; set; }
        public int? PurchaseDataId { get; set; }
        public decimal? GamePrice { get; set; }
        public string GamePicture { get; set; }
        public string GameVideo { get; set; }
        public string GameIntroduction { get; set; }
        public string GameDetailsText { get; set; }
        public int? TotalBuyCount { get; set; }
        public string SystemOperation { get; set; }
        public string SystemUseSize { get; set; }
        public string SystemGraphCard { get; set; }
        public string SystemMemory { get; set; }
        public DateTime? ReleadeDate { get; set; }

        public virtual GameDiscount Discount { get; set; }
        public virtual GameType GameTyple { get; set; }
        public virtual PurchaseDatum PurchaseData { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<MyForum> MyForums { get; set; }
        public virtual ICollection<MyGame> MyGames { get; set; }
        public virtual ICollection<Wish> Wishes { get; set; }
    }
}
