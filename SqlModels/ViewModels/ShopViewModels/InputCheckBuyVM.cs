using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.ViewModels.ShopViewModels
{
    public class InputCheckBuyVM
    {
            public string UserId { get; set; }
            public int GameId { get; set; }
            public string GameName { get; set; }
            public string GameUrl { get; set; }
            public decimal GamePrice { get; set; }
    }
}
