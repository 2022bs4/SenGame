using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.ViewModels
{
    public class CommunityIndexViewModel
    {
        //Game遊戲表單

        public List<GameData> GameList { get; set; }

        public class GameData
        {
            public int GameId { get; set; }
            public string GameName { get; set; }
            public string GameIntroduction { get; set; }
            public string MediaUrl { get; set; }

        }
    }
}
