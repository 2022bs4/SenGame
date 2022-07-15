using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.DTOModels
{
    public class UserDTO
    {   
        //我的遊戲庫的所有的遊戲集合(未分類)
        public  List<GameData> gamelist { get;set; }
        //我的遊戲庫的所有的遊戲集合(我的最愛)
        public List<GameData> myfavourite { get; set; }

        public List<GameDetail> GetGameDetails { get; set; }

        public class GameData
        {
            public string Id { get; set; }
            public string GameName { get; set; }
            public string GameIntroduction { get; set; }
            public string MediaUrl { get; set; }
        }
        //回傳字串到service裡面
        public class Game_Name
        {
            public string GameName { get; set; }
        }

        public class GameDetail
        {
            public string GameName { get; set; }
            public string GameIntroduction { get; set; }
            public DateTime ReleaseTime { get; set; }
            public string Developer { get; set; }
            public string Marker { get; set; }
            public string MediaUrl { get; set; }
            public List<GameSwiper> GameSwipers{ get; set; }

            public class GameSwiper
            {
                public string MediaUrl { get; set; }
            }
        }
             
    }
}
