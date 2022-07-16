using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SqlModels.ViewModels
{
    public class ProductDetailsVM
    {
        //複數
        public  List<ProductInformation> ProductPlural { get; set; }
        //單一
        public  ProductInformation ProductItem { get; set; }
        public class ProductInformation {
            public int GameId { get; set; }
            public string GameName { get; set; }
            public string GamePicture { get; set; }

            [Required]
            [DisplayFormat(DataFormatString = "{0:0,000}", ApplyFormatInEditMode = true)]
            public decimal GamePrice { get; set; }
            public string GameIntroduction { get; set; }
            public DateTime ReleaseTime { get; set; }
            public string Developer { get; set; }
            public string Marker { get; set; }
        }
        //標籤
        public List<TypleData> GameTyple { get; set; }
        public class TypleData
        {
            public int GameId { get; set; }
            public string TypleName { get; set; }
        }
        //折扣
        public double DisscountTake { get; set; }
        
    }
}
         