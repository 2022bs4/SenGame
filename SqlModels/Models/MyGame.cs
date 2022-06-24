using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class MyGame
    {
        public int MyGameId { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public int? MyFavouriteId { get; set; }
    }
}
