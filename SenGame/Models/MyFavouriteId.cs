using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class MyFavouriteId
    {
        public MyFavouriteId()
        {
            MyGames = new HashSet<MyGame>();
        }

        public int MyFavouriteId1 { get; set; }
        public int GameId { get; set; }

        public virtual ICollection<MyGame> MyGames { get; set; }
    }
}
