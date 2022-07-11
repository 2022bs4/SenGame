using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class MyFavouriteId
    {
        public int MyFavouriteId1 { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
