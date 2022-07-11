using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.ViewModels
{
    public class GameLibraryViewModel
    {
        public List<GameData> GameList { get; set; }

        public class GameData
        {
            public string Id { get; set; }
            public string GameName { get; set; }
            public string GameIntroduction { get; set; }
            public string MediaUrl { get; set; }
        }
    }
}
