using System;

namespace SqlModels.ViewModels
{
    public class ProductDetailsViewModel
    {
        //遊戲主要資訊
        public int GameId { get; set; }
        public string GameName { get; set; }
        public decimal GamePrice { get; set; }
        public string GameIntroduction { get; set; }
        public DateTime ReleaseTime { get; set; }
        public string Developer { get; set; }
        public string Marker { get; set; }

        //簡介圖
        public string ProductMainPicture { get; set; }

        //標籤
        public string TypleName { get; set; }

        //折扣
        public double DisscountTake { get; set; }
        
    }
}
