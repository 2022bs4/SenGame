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
        public List<GameData> MyFavourite { get; set; }
        public List<GameDetail> GetGameDetails { get; set; }
        


        public class GameData
        {
            public string Id { get; set; }
            public string GameName { get; set; }
            public string GameIntroduction { get; set; }
            public string MediaUrl { get; set; }
        }
        //接收字串
        public class EditGame
        {
            public string GameName { get; set; }
            public bool MyFavourite { get; set; }
        }
        public class GameDetail
        {
            public string GameName { get; set; }
            public string GameIntroduction { get; set; }
            public DateTime ReleaseTime { get; set; }
            public string Developer { get; set; }
            public string Marker { get; set; }
            public string MediaUrl { get; set; }
            public List<GameSwiper> GameSwipers { get; set; }

            public class GameSwiper
            {
                public string MediaUrl { get; set; }
            }
        }
    }
}
