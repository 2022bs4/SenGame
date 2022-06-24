using System;

namespace SenGame.ViewModels
{
    public class ProductDetailsViewModel
    {
        //遊戲主要資訊
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GameIntroduction { get; set; }
        public string GameDetailsText { get; set; }
        public DateTime ReleaseTime { get; set; }
        public string Developer { get; set; }
        public string Marker { get; set; }

        //系統規格
        public int SystemType { get; set; }
        public string Hddspace { get; set; }
        public string System { get; set; }
        public string SystemRam { get; set; }
        public string SystemCpu { get; set; }
        public string SystemGpu { get; set; }
        
        
        //媒體
        public string MediaUrl { get; set; }
    }
}
