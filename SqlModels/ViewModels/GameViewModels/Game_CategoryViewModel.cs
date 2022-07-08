using SqlModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.ViewModels
{

    public class Game_CategoryViewModel
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



    
}
