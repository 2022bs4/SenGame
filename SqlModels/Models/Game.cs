using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class Game
    {
        public Game()
        {
            CustomerServices = new HashSet<CustomerService>();
            Forums = new HashSet<Forum>();
            GameDiscounts = new HashSet<GameDiscount>();
            GameMedia = new HashSet<GameMedium>();
            GameTypes = new HashSet<GameType>();
            MyFavouriteIds = new HashSet<MyFavouriteId>();
            MyGames = new HashSet<MyGame>();
            Orderdetails = new HashSet<Orderdetail>();
            ShoppingCarts = new HashSet<ShoppingCart>();
            SystemSpecifications = new HashSet<SystemSpecification>();
            Wishes = new HashSet<Wish>();
        }

        public int GameId { get; set; }
        public string GameName { get; set; }
        public decimal GamePrice { get; set; }
        public string GameIntroduction { get; set; }
        public string GameDetailsText { get; set; }
        public int? TotalBuyCount { get; set; }
        public DateTime ReleaseTime { get; set; }
        public DateTime? DownTime { get; set; }
        public string Developer { get; set; }
        public string Marker { get; set; }

        public virtual ICollection<CustomerService> CustomerServices { get; set; }
        public virtual ICollection<Forum> Forums { get; set; }
        public virtual ICollection<GameDiscount> GameDiscounts { get; set; }
        public virtual ICollection<GameMedium> GameMedia { get; set; }
        public virtual ICollection<GameType> GameTypes { get; set; }
        public virtual ICollection<MyFavouriteId> MyFavouriteIds { get; set; }
        public virtual ICollection<MyGame> MyGames { get; set; }
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public virtual ICollection<SystemSpecification> SystemSpecifications { get; set; }
        public virtual ICollection<Wish> Wishes { get; set; }
    }
}
