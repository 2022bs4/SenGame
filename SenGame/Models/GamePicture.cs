using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class GamePicture
    {
        public int GamePictureId { get; set; }
        public string PhotoUrl { get; set; }
        public int GameId { get; set; }
        public string Instructions { get; set; }

        public virtual Game Game { get; set; }
    }
}
