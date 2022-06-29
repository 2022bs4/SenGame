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
        public bool MyFavourite { get; set; }

        public virtual Game Game { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
