using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class Typelist
    {
        public Typelist()
        {
            GameTypes = new HashSet<GameType>();
        }

        public int TypelistId { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }

        public virtual ICollection<GameType> GameTypes { get; set; }
        public virtual TypeGroup TypeGroup { get; set; }
    }
}
