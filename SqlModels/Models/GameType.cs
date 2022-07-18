using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class GameType
    {
        public int GameTypeId { get; set; }
        public int GameId { get; set; }
        public int TypelistId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Typelist Typelist { get; set; }
    }
}
