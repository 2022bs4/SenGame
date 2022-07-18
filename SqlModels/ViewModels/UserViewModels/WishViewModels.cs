using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.ViewModels.UserViewModels
{
    public class WishViewModels
    {
        //使用者名
        public string UserName { get; set; }
        //願望清單索引
        public int WishId { get; set; }
        //遊戲網址
        public string GameUrl { get; set; }
        //遊戲名
        public string GameName { get; set; }
        //遊戲投影片
        public List<GameSlide> GameSlides { get; set; }

        public class GameSlide
        {
            public string MediaUrl { get; set; }
        }
        //遊戲推出日期
        public DateTime ReleaseTime { get; set; }
        //遊戲價格
        public decimal GamePrice { get; set; }
        //願望清單加入日期
        public DateTime? AddTime { get; set; }

        
    }
}
