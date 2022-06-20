using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class GameType
    {
        public GameType()
        {
            Games = new HashSet<Game>();
        }

        public int GameTypeId { get; set; }
        public int GameId { get; set; }
        public int TypelistId { get; set; }

        public virtual Typelist Typelist { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
