using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class Typelist
    {
        public Typelist()
        {
            GameTypes = new HashSet<GameType>();
        }

        public int TypelistId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GameType> GameTypes { get; set; }
    }
}
