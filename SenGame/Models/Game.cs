using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class Game
    {
        public Game()
        {
            Forums = new HashSet<Forum>();
            GameMedia = new HashSet<GameMedium>();
            GameTypes = new HashSet<GameType>();
            GameVideos = new HashSet<GameVideo>();
            MyGames = new HashSet<MyGame>();
            SystemSpecifications = new HashSet<SystemSpecification>();
            Wishes = new HashSet<Wish>();
        }

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

        public virtual GameDiscount Discount { get; set; }
        public virtual ICollection<Forum> Forums { get; set; }
        public virtual ICollection<GameMedium> GameMedia { get; set; }
        public virtual ICollection<GameType> GameTypes { get; set; }
        public virtual ICollection<GameVideo> GameVideos { get; set; }
        public virtual ICollection<MyGame> MyGames { get; set; }
        public virtual ICollection<SystemSpecification> SystemSpecifications { get; set; }
        public virtual ICollection<Wish> Wishes { get; set; }
    }
}
