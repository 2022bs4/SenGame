using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class MyGame
    {
        public int MyGameId { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}
