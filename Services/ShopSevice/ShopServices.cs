using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
using SqlModels.DTOModels;
using SqlModels.Models;
using SqlModels.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class ShopServices : BaseService, IShopServices
    {
        
        public ShopServices(IRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        //Index標籤讀取
        public async Task<IEnumerable<ResponseTypeGroupDTO>> GetIndexTag() {
            var typeGroup =  Repository.GetAll<TypeGroup>();
            var typelist = Repository.GetAll<Typelist>();
            var type = await typeGroup.Join(typelist, x => x.GroupId, y => y.GroupId,
                (x, y) => new { x.GroupName, y.Name }).OrderByDescending(x => x.GroupName).ToListAsync();
                var result = type.GroupBy(x => x.GroupName).Select(r => 
                new ResponseTypeGroupDTO
                {
                    ParentCategory = r.Key,
                    GameTyple = r.ToList().Select(item=> 
                    new ResponseTypeGroupDTO.Data 
                    { TypleName = item.Name }).ToList(),
                });
            return  result;
        } 



        //獲取指定數量及是否上架之遊戲Method
        public async Task<List<IndexList>> GetSingleProducts(int IsShop)
        {
            var game = Repository.GetAll<Game>().Where(x => x.ReleaseState == IsShop);
            var pic = Repository.GetAll<GameMedium>().Where(x => x.InstructionType == 2 && x.Instruction == 1);
            var gameMedia = await game.Join(pic, x => x.GameId, p => p.GameId, (x, p) =>
            new IndexList {
                GameId = x.GameId,
                GameName = x.GameName,
                GameIndexPicture = p.MediaUrl,
                GamePrice = x.GamePrice,
                ReleaseTime = x.ReleaseTime,
                TotalBuyCount = x.TotalBuyCount
            }).ToListAsync();
            return gameMedia;
        }
        //基於首頁Swipper衍生之Method
        public async Task<List<ResponseProductItem>> GetProductItem(int IsShop)
        {
            var gameMedium = await GetSingleProducts(IsShop);
            var result = new List<ResponseProductItem>();
            foreach (var item in gameMedium)
            {
                result.Add(new ResponseProductItem
                {
                    GameId = item.GameId,
                    GameName = item.GameName,
                    GamePrice = item.GamePrice,
                    GameUrl = item.GameIndexPicture,
                    Date = item.ReleaseTime,
                    TotalBuyCount = item.TotalBuyCount,
                });
            }
            return result;
        }
        //首頁Method
        public async Task<IndexProductDTO> GetIndesSwipper(string request)
        {
            var response = await GetProductItem(1);
            var firstArea = new List<ResponseProductItem>();
            var secondArea = new List<ResponseProductItem>();
            if (request == "人氣最高")
            {
                response.Sort((x,y)=> -x.TotalBuyCount.CompareTo(y.TotalBuyCount));
                firstArea = response.Take(7).ToList();
                secondArea = response.Skip(4).Take(3).ToList();
                return SwipperModel(firstArea, secondArea);
            }

            //日期
            else if (request == "最新發行日期")
            {
                response.Sort((x, y) => -x.Date.CompareTo(y.Date));
                firstArea = response.Take(7).ToList();
                secondArea = response.Skip(4).Take(3).ToList();
                return SwipperModel(firstArea, secondArea);
            }
            else if (request == "較早發行日期")
            {
                
                response.Sort((x, y) => x.Date.CompareTo(y.Date));
                firstArea = response.Take(7).ToList();
                secondArea = response.Skip(4).Take(3).ToList();
                return SwipperModel(firstArea, secondArea);
            }
            else if (request == "即將發行")
            {
                //firstArea = await GetProductItem(2);
                //firstArea.OrderByDescending(x => x.Date).Take(7);
                //secondArea = await GetProductItem(1);
                ////之後要skip()
                //secondArea.OrderByDescending(x => x.Date).Take(3);
            }

            //價錢
            else if (request == "價格由低至高")
            {
                response.Sort((x,y)=>x.GamePrice.CompareTo(y.GamePrice));
                firstArea = response.Take(7).ToList();
                secondArea = response.Skip(4).Take(3).ToList();
                return SwipperModel(firstArea, secondArea);
            }
            else if (request == "價格由高至低")
            {
                response.Sort((x, y) => -x.GamePrice.CompareTo(y.GamePrice));
                firstArea = response.Take(7).ToList();
                secondArea = response.Skip(4).Take(3).ToList();
                return SwipperModel(firstArea, secondArea);
            }

            return null; 

        }
        public IndexProductDTO SwipperModel(List<ResponseProductItem> a , List<ResponseProductItem> b) 
        {
            var result = new IndexProductDTO
            {
                FirstAreaProduct = a,
                SecondAreaProduct = b
            };
            return result;
        } 

        
        //抓取全圖片版銷售最好(之後會將其他需求擴充至此)
        public async Task<List<IndexList>> GetProductList()
        {
            var game = await GetSingleProducts(1);

            //之後會添加判斷是來篩選各類需求產品排序
            var newGame = game.OrderBy(x => x.ReleaseTime).Take(5);

            var result = new List<IndexList>();
            foreach (var item in newGame)
            {
                result.Add(new IndexList
                {
                    GameId = item.GameId,
                    GameName = item.GameName,
                    GamePrice = item.GamePrice,
                    GameIndexPicture = item.GameIndexPicture,
                });
            }
            return result;
        }
        //更多list
        //public async Task<List<IndexList>> GetMoreProductList()
        //{ 

        //};

        //GetProductList  多徒多標籤介紹
        public async Task<IndexList> GetDetailsList(int id)
        {
            var game = await GetProductItemDateals(id);
           
            var pic = await Repository.FindBy<GameMedium>(x => x.GameId == id && x.InstructionType == 1 && x.Instruction == 1).OrderByDescending(x => x.Sort).ToListAsync();
            var result = new IndexList()
            {
                GameId = game.GameId,
                GameName = game.GameName,
                GamePrice = game.GamePrice,
                TypeData = game.GameTyple.Select(item => new IndexList.ProductType
                { 
                    TypleName = item.TypleName 
                }).ToList(),
                GameUrl = pic.Select(item=> new IndexList.ProductUrl {
                    Url = item.MediaUrl 
                }).ToList()
            };
            return result;
        }

        //商品詳細頁面
        public async Task<ResponseProducDetailsDTO> ProductView(int id)
        {
            var getGame = await GetProductItemDateals(id);
            var pic = await Repository.FindBy<GameMedium>(x => x.GameId == id && x.InstructionType == 2 && x.Instruction == 1).FirstOrDefaultAsync();
            
            var discount = await Repository.FindBy<GameDiscount>(x => x.GameId == id ).FirstOrDefaultAsync();

            var result = new ResponseProducDetailsDTO()
            { 
                GameId = getGame.GameId,
                GameName = getGame.GameName,
                GamePrice = getGame.GamePrice,
                GameIntroduction = getGame.GameIntroduction,
                ReleaseTime = getGame.ReleaseTime,
                Developer = getGame.Developer,
                Marker = getGame.Marker,
                DisscountTake = discount.DiscountTake,
                GameTyple = getGame.GameTyple,
                GamePicture = pic.MediaUrl,
            };
            return result;
        }

        public async Task<ResponseProducDetailsDTO> GetProductItemDateals(int id) 
        {
            var game = await Repository.FindBy<Game>(x => x.GameId == id).FirstOrDefaultAsync();
            var typle = Repository.FindBy<GameType>(x => x.GameId == id);
            var typlist = Repository.GetAll<Typelist>();
            var gameTyple = await typle.Join(typlist, x => x.TypelistId, y => y.TypelistId, (x, y) => new { x.GameId, y.Name }).ToListAsync();

            var result = new ResponseProducDetailsDTO()
            {
                GameId = game.GameId,
                GameName = game.GameName,
                GamePrice = game.GamePrice,
                GameIntroduction = game.GameIntroduction,
                ReleaseTime = game.ReleaseTime,
                Developer = game.Developer,
                Marker = game.Marker,
                GameTyple = gameTyple.Select(item => new ResponseProducDetailsDTO.TypleData
                {
                    GameId = item.GameId,
                    TypleName = item.Name,
                }).ToList(),
            };
            return result;
        }

        //以下為商品詳細之GET API 考慮整合
        public async Task<RequestProducDetailsDTO> ProductSwipper(int id)
        {
            var pic = await Repository.FindBy<GameMedium>(x => x.GameId == id && x.InstructionType == 1 && x.Instruction == 1).OrderByDescending(x => x.Sort).ToListAsync();

            var result = new RequestProducDetailsDTO()
            {
                SwipperData = pic.Select(
                    item => new RequestProducDetailsDTO.ResponseProductSwipperDTO 
                    {
                    SwipperUrl=item.MediaUrl
                }).ToList(),
            };
            return result;
        }
        public  async Task<List<ProdductIntroductDTO>> ProductMainText(int id)
        {
            var game = await Repository.FindBy<Game>(x => x.GameId == id).Select(x=>x.GameDetailsText).FirstAsync();

            var gameArray = game.Split("<img>");
            var pic = await Repository.FindBy<GameMedium>(x => x.GameId == id && x.InstructionType == 3 && x.Instruction == 1).ToListAsync();

            var result = new List<ProdductIntroductDTO>();
            int i = 0;
            result.Add(new ProdductIntroductDTO
            {
                GameDetailsText = gameArray[i],
            });
            i++;
            if (gameArray.Length > 1)
            {
                foreach (var item in pic)
                {
                    var newtext = gameArray[i].Insert(0, $"<img src='{item.MediaUrl}'' class='w-100''>");
                    result.Add(new ProdductIntroductDTO
                    {
                        GameDetailsText = newtext,
                    });
                    i++;
                }
            }
            return  result  ;
        }
        public async Task<RequestProducDetailsDTO> ProductSystem(int id)
        {
            var system = await Repository.FindBy<SystemSpecification>(x => x.GameId == id).ToListAsync();

            var result = new RequestProducDetailsDTO()
            {
                SystemData =  system.Select(item =>
                new RequestProducDetailsDTO.ProductSystemDTO
                {
                    SystemType = item.SystemType,
                    Configure = item.Configure,
                    Hddspace = item.Hddspace,
                    System = item.System,
                    SystemRam = item.SystemRam,
                    SystemCpu = item.SystemCpu,
                    SystemGpu = item.SystemGpu,
                }).ToList(),
            };
            return result;
        }
        
        //遊戲推薦有兩個頁面有使用，考慮重構和封裝
        public async Task<List<ProductRecommend>> ProductRecommend()
        {
            var recommend =  Repository.GetAll<Game>().OrderBy(x => Guid.NewGuid());

            var pic =  Repository.GetAll<GameMedium>().Where(x => x.InstructionType == 2 && x.Instruction == 1);
            var newRecommend = await recommend.Join(pic, r => r.GameId, p => p.GameId, (r, p) => new { r.GameId, r.GameName, r.GamePrice, p.MediaUrl }).Take(5).ToListAsync();
            var result = new List<ProductRecommend>();
            foreach (var item in newRecommend)
            {
                result.Add(new ProductRecommend
                {
                    GameId = item.GameId,
                    ProductUrl = item.MediaUrl,
                    ProductName = item.GameName,
                    ProductPrice = item.GamePrice,
                });
            }
            return result;
        }
    
    }

}

