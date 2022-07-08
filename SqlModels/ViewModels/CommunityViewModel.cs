using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.ViewModels
{
    public class CommunityViewModel
    {
        //Game遊戲表單
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GameIntroduction { get; set; }
        //GameMedia 圖片
        public string MediaUrl { get; set; }
    }
}
