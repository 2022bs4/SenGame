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
    public class ShopServices : BaseService
    {
        public ShopServices(IRepository repository, IMapper mapper) : base(repository, mapper )
        {
        }

        public ProductViewDTO ProductView(int id)
        {
            var game = Repository.FindBy<Game>(x => x.GameId == id).FirstOrDefault();

            var pic = Repository.FindBy<GameMedium>(x => x.GameId == id && x.InstructionType == 2 && x.Instruction == 1).FirstOrDefault();
            
            var discount = Repository.FindBy<GameDiscount>(x => x.GameId == id ).FirstOrDefault();

            var typle = Repository.FindBy<GameType>(x => x.GameId == id);
            var typlist = Repository.GetAll<Typelist>();
            var gameTyple = typle.Join(typlist, x => x.TypelistId, y => y.TypelistId, (x, y) =>new { x.GameId, y.Name });

            var result = new ProductViewDTO()
            { 
                GameId = game.GameId,
                GameName = game.GameName,
                GamePrice = game.GamePrice,
                GameIntroduction = game.GameIntroduction,
                ReleaseTime = game.ReleaseTime,
                Developer = game.Developer,
                Marker = game.Marker,
                DisscountTake = discount.DiscountTake,
                GameTyple = gameTyple.Select(item=> new ProductViewDTO.TypleData 
                { 
                    GameId=item.GameId,
                    TypleName=item.Name,
                }),
                GamePicture = pic.MediaUrl,
            };

            return result;
        }
        public async Task<List<ProductSwipperDTO>> ProductSwipper(int id)
        {
            var pic = await Repository.FindBy<GameMedium>(x => x.GameId == id && x.InstructionType == 1 && x.Instruction == 1).OrderByDescending(x => x.Sort).ToListAsync();

            var result = new List<ProductSwipperDTO>();
            foreach(var item in pic)
            {
                result.Add(new ProductSwipperDTO { SwipperUrl = item.MediaUrl });
            }
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
        public async Task<List<ProductSystemDTO>> ProductSystem(int id)
        {
            var system = await Repository.FindBy<SystemSpecification>(x => x.GameId == id).ToListAsync();

            var result = new List<ProductSystemDTO>();

            foreach (var item in system)
            {
                result.Add(
                    new ProductSystemDTO
                    {
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
        public async Task<List<ProductRecommend>> ProductRecommend()
        {
            var recommend = Repository.GetAll<Game>().OrderBy(x => Guid.NewGuid());

            var pic = Repository.GetAll<GameMedium>().Where(x => x.InstructionType == 2 && x.Instruction == 1);
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

