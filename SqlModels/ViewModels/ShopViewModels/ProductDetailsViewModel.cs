using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SqlModels.ViewModels
{
    public class ProductDetailsViewModel
    {
        //遊戲主要資訊
        public int GameId { get; set; }
        public string GameName { get; set; }

        
        [DisplayFormat(DataFormatString = "{0:0,000}", ApplyFormatInEditMode = true)]
        public int GamePrice { get; set; }
        public string GameIntroduction { get; set; }
        public DateTime ReleaseTime { get; set; }
        public string Developer { get; set; }
        public string Marker { get; set; }

        //簡介圖
        public string GamePicture { get; set; }

        //標籤
        public IQueryable<TypleData> GameTyple { get; set; }
        public class TypleData
        {
            public int GameId { get; set; }
            public string TypleName { get; set; }
        }

        //折扣
        public double DisscountTake { get; set; }
        
    }
}
