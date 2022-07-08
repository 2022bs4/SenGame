using SqlModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.ViewModels
{

    public class GameViewModel
    {
        public List<RecommendViewModel> RecommendVM { get; set; }
        public List<SpecialDiscountViewModel> SpecialDiscountVM { get; set; }
        public List<PopVRViewModel> PopVRVM { get; set; }
        public List<LossThenPriceViewModel> LossThenPriceVM { get; set; }
        public List<UpdateDiscountViewModel> UpdateDiscountVM { get; set; }
        public List<TabViewModel> TabNewVM { get; set; }
        public List<TabViewModel> TabHotVM { get; set; }
        public List<TabViewModel> TabBeReleaseVM { get; set; }
        public List<TabViewModel> TabSpecialDiscountVM { get; set; }

    }



    public class RecommendViewModel
    {
        //主圖網址 來自gameMedia
        public string MainImgUrl { get; set; }

        //遊戲名稱 來自Game
        public string Name { get; set; }

        //List<遊戲圖> 來自gameMedia
        public List<string> ImgUrlList { get; set; }

        //是否推出

        //List<種類> 來自GameType
        public List<string> Types { get; set; }

        //折價 來自GameDiscount
        public double Discount { get; set; }

        //原價 來自Game
        public decimal OriginalPrice { get; set; }

        //折價後價格
        public decimal DiscountPrice { get; set; }

        //發布時間
        public DateTime ReleaseTime { get; set; }

        //List<蘋果微軟圖片>

        




    }

    public class TabViewModel
    {
        //主圖網址 來自gameMedia
        public string MainImgUrl { get; set; }

        //遊戲名稱 來自Game
        public string Name { get; set; }

        //List<遊戲圖> 來自gameMedia
        public List<string> ImgUrlList { get; set; }

        //是否推出

        //List<種類> 來自GameType
        public List<string> Types { get; set; }

        //折價 來自GameDiscount
        public double Discount { get; set; }

        //原價 來自Game
        public decimal OriginalPrice { get; set; }

        //折價後價格
        public decimal DiscountPrice { get; set; }

        //發布時間
        public DateTime ReleaseTime { get; set; }

        //List<蘋果微軟圖片>

    }


    public class SpecialDiscountViewModel
    {
        public string MainImgUrl { get; set; }

        //遊戲名稱 來自Game
        public string Name { get; set; }
        
        //折價 來自GameDiscount
        public double Discount { get; set; }

        //原價 來自Game
        public decimal OriginalPrice { get; set; }

        //折價後價格
        public decimal DiscountPrice { get; set; }

        //發布時間
        public DateTime Endtime { get; set; }

    }

    public class PopVRViewModel
    {
        public string MainImgUrl { get; set; }

        //遊戲名稱 來自Game
        public string Name { get; set; }

        //折價 來自GameDiscount
        public double Discount { get; set; }

        //原價 來自Game
        public decimal OriginalPrice { get; set; }

        //折價後價格
        public decimal DiscountPrice { get; set; }       

    }
    public class LossThenPriceViewModel
    {
        public string MainImgUrl { get; set; }

        //遊戲名稱 來自Game
        public string Name { get; set; }

        //折價 來自GameDiscount
        public double Discount { get; set; }

        //原價 來自Game
        public decimal OriginalPrice { get; set; }

        //折價後價格
        public decimal DiscountPrice { get; set; }

    }

    public class UpdateDiscountViewModel
    {
        public string MainImgUrl { get; set; }

        //遊戲名稱 來自Game
        public string Name { get; set; }

        //折價 來自GameDiscount
        public double Discount { get; set; }

        //原價 來自Game
        public decimal OriginalPrice { get; set; }

        //折價後價格
        public decimal DiscountPrice { get; set; }

    }
}
