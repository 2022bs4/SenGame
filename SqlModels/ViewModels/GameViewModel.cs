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
        //主圖網址 來自gameMedia
        public List<string> MainImgUrl { get; set; }

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

        public string Specxial_discount_Img { get; set; }

        public string Specxial_discount_date { get; set; }

        public string Specxial_discount_Discount { get; set; }





    }
}
