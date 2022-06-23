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
            Typelists = new HashSet<Typelist>();
        }

        public int GameTypeId { get; set; }
        public int GameId { get; set; }

        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<Typelist> Typelists { get; set; }

        public static implicit operator GameType(int v)
        {
            throw new NotImplementedException();
        }
    }
}
