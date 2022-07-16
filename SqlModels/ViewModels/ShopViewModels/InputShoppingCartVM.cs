using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.ViewModels.ShopViewModels
{
    public class InputShoppingCartVM
    {
        public string UserId { get; set; }
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GameUrl { get; set; }
        public int GamePrice { get; set; }
        public DateTime Created { get; set; }

        public string Success { get; set; }
    }
    public class OutputShoppingCart 
    {
        public int GameId { get; set; }

        public string SelectId { get; set; }
    }
}
