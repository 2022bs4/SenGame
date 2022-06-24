using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class GameType
    {
        public int GameTypeId { get; set; }
        public int GameId { get; set; }
        public int? TypelistId { get; set; }
    }
}
