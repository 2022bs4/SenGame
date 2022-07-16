using System;
using System.Collections.Generic;
using System.Linq;


namespace SqlModels.DTOModels
{
    //產品詳細Razor部分
    public class ResponseProducDetailsDTO
    {
        public List<TypleData> GameTyple { get; set; }

        public class TypleData
        {
            public int GameId { get; set; }
            public string TypleName { get; set; }
        }


        //遊戲主要資訊
        public int GameId { get; set; }
        public string GameName { get; set; }
        public decimal GamePrice { get; set; }
        public string GameIntroduction { get; set; }
        public DateTime ReleaseTime { get; set; }
        public string Developer { get; set; }
        public string Marker { get; set; }
        public string GamePicture { get; set; }
        //折扣
        public double DisscountTake { get; set; }

        
    }












    //產品詳細Json
    public class RequestProducDetailsDTO {

        public List<ResponseProductSwipperDTO> SwipperData{ get; set; }


        public class ResponseProductSwipperDTO
        {
            public string SwipperUrl { get; set; }
        }

        public List<ProductSystemDTO> SystemData { get; set; }

        public class ProductSystemDTO
        {
            //系統規格
            public int? Configure { get; set; }
            public int SystemType { get; set; }
            public string Hddspace { get; set; }
            public string System { get; set; }
            public string SystemRam { get; set; }
            public string SystemCpu { get; set; }
            public string SystemGpu { get; set; }
        }

    }
    public class ProdductIntroductDTO
    {
        public string GameDetailsText { get; set; }
    }

    //推薦遊戲區
    public class ProductRecommend
    { 
        public int GameId { get; set; }
        public string ProductUrl { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

    }

}
