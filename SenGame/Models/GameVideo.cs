using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class GameVideo
    {
        public int GameVideoId { get; set; }
        public string VideoUrl { get; set; }
        public int GameId { get; set; }
        public string Instructions { get; set; }
    }
}
