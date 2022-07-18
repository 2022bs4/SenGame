using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.DTOModels
{
    public class IndexProductDTO {
        public List<ResponseProductItem> FirstAreaProduct { get; set; }
        public List<ResponseProductItem> SecondAreaProduct { get; set; }

        public string UserRequest { get; set; }

        public List<ResponseProductItem> CardProduct { get; set; }
    }
    public class ResponseProductItem
    {
        public string UserId { get; set; }
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GameUrl { get; set; }
        public decimal GamePrice { get; set; }
        public DateTime Date { get; set; }
    }

    public class IndexList
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public decimal GamePrice { get; set; }
        public string  GameIndexPicture { get; set; }

        public DateTime ReleaseTime { get; set; }
        public int ReleaseState {get; set; }



        public List<ProductUrl> GameUrl { get; set; }

        public class ProductUrl
        {
            public string Url { get; set; }
        }

        public List<ProductType> TypeData { get; set; }

        public class ProductType
        {
            public int GameId { get; set; }
            public string TypleName { get; set; }
        }
    }
}
