using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.DTOModels
{
    public class CommunityDTO
    {
        //Game遊戲表單
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GameIntroduction { get; set; }
        //GameMedia 圖片
        public string MediaUrl { get; set; }

    }


    public class Swipers
    {
        public string MediaUrl { get; set; }
    }
    
}
