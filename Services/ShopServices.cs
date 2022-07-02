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
    public class ShopServices : BaseService<Game>, IShopServices
    {
        private readonly IRepository<Game> _game;
        private readonly IRepository<GameMedium> _gameMedium;
        private readonly IRepository<Typelist> _typelist;
        private readonly IRepository<GameType> _gametype;
        private readonly IRepository<GameDiscount> _discount;
        private readonly IRepository<SystemSpecification> _productSystem;
        //private readonly IRepository<ProductViewDTO> _productView;

        public ShopServices(IRepository<Game> repository, IRepository<GameMedium> gameMedium, IRepository<Typelist> typlist , IRepository<GameType> gameTyple , IRepository<GameDiscount> disscount , IRepository<SystemSpecification> productSystem , IRepository<ProductViewDTO> productView) : base(repository)
        {
            this._game = repository;
            this._gameMedium = gameMedium;
            this._typelist = typlist;
            this._gametype = gameTyple;
            this._discount = disscount;
            this._productSystem = productSystem;
            //this._productView = productView;

        }

        public List<ProductViewDTO> ProductView(int id)
        {
            var game = _game.GetById(id);
            var medium = _gameMedium.GetAll().Where(x => x.GameId == id && x.InstructionType == 2 && x.Instruction == 1).FirstOrDefault();
            var disscount = _discount.GetAll().Where(x => x.GameId == id).FirstOrDefault();
            var typelist = _typelist.GetAll();
            var gameType = _gametype.GetAll();
            var productList = gameType.Join(typelist, g => g.TypelistId, s => s.TypelistId, (g, s) => new { g.GameId, s.Name }).Where(x=>x.GameId==id);

            var productView = new List<ProductViewDTO>();
            foreach (var typle in productList)
            {
                productView.Add(new ProductViewDTO
                {
                    GameId = game.GameId,
                    GameName = game.GameName,
                    GamePrice = game.GamePrice,
                    GameIntroduction = game.GameIntroduction,
                    ReleaseTime = game.ReleaseTime,
                    Developer = game.Developer,
                    Marker = game.Marker,
                    DisscountTake =disscount.DiscountTake,
                    TypleName = typle.Name,
                    ProductMainPicture = medium.MediaUrl,
                });   
            };

            return productView;
        }
        public  List<ProductSwipperDTO> ProductSwipper(int id)
        {
            var media = _gameMedium.GetAll().Where(x => x.GameId == id && x.InstructionType == 1 && x.Instruction == 1).OrderByDescending(x => x.Sort);

            var result = new List<ProductSwipperDTO>();
            foreach (var swipper in media)
            {
                result.Add(new ProductSwipperDTO { SwipperUrl = swipper.MediaUrl });
            }

            return result;
        }
        public List<ProdductIntroductDTO> ProductMainIntroduct(int id)
        {
            var game = _game.GetById(id);

            var media = _gameMedium.GetAll().Where(x => x.GameId == id && x.InstructionType == 3 && x.Instruction == 1);

            var result = new List<ProdductIntroductDTO>();
            foreach (var itme in media)
            {
                result.Add(new ProdductIntroductDTO
                {
                    GameId = itme.GameId,
                    ProductName = game.GameName,
                    GameDetailsText = game.GameDetailsText,
                    DetailsPicFirst = itme.MediaUrl,
                });
            }

            return result;
        }

        public  List<ProductSystemDTO> ProductSystem(int id)
        { 
            var system =  _productSystem.GetAll().Where(x => x.GameId == id).ToList();
            var result = new List<ProductSystemDTO>();

            foreach (var item in system)
            {
                result.Add(
                    new ProductSystemDTO
                    {
                        GameId = item.GameId,
                        SystemType = item.SystemType,
                        Configure = item.Configure,
                        Hddspace = item.Hddspace,
                        System = item.System,   
                        SystemRam = item.SystemRam,
                        SystemCpu = item.SystemCpu,
                        SystemGpu = item.SystemGpu,
                    });
            }

            return result;
        }
        public List<ProductRecommend> ProductRecommend()
        {
            var recommend = _game.GetAll().OrderBy(x => Guid.NewGuid());
            var pic = _gameMedium.GetAll().Where(x => x.InstructionType == 2 && x.Instruction == 1);
            var result = recommend.Join(pic, r => r.GameId, p => p.GameId, (r, p) => new { r.GameId, r.GameName, r.GamePrice, p.MediaUrl }).Take(2).ToList();
            var productRecommend = new List<ProductRecommend>();
            foreach (var item in result)
            {
                productRecommend.Add(new ProductRecommend
                {
                    GameId = item.GameId,
                    ProductUrl = item.MediaUrl,
                    ProductName = item.GameName,
                    ProductPrice = item.GamePrice,
                 });
            }
            return productRecommend;
        }
    }
}
