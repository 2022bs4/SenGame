using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class Typelist
    {
        public int TypelistId { get; set; }
        public string Name { get; set; }
        public int? GameTypeId { get; set; }

        public virtual GameType GameType { get; set; }
    }
}
