using Services.Interface;
using SqlModels.DTOModels;
using SqlModels.Models;
using SqlModels.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SqlModels.DTOModels.UserDTO;

namespace Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IRepository repository) : base(repository)
        {

        }

        public UserDTO UncategorizedGame(string UserId)
        {
            //uncategorized 未分類
            //my favourite  我的最愛

            var uncategorized = Repository.GetAll<MyGame>().Where(u => u.Id == UserId && u.MyFavourite == false);
            var img = Repository.GetAll<GameMedium>().Where(i => i.InstructionType == 2 && i.Instruction == 1);
            var gametotal = Repository.GetAll<Game>();
            var mygame = uncategorized.Join(img, g => g.GameId, i => i.GameId, (g, s) => new { g.GameId, g.Id, s.MediaUrl });
            var z = mygame.Join(gametotal, mg => mg.GameId, gt => gt.GameId, (mg, gt) => new { gt.GameName, mg.MediaUrl, mg.Id, mg.GameId }).ToList();
            var gamelist = new UserDTO()
            {
                gamelist = z.Select(item => new UserDTO.GameData
                {
                    Id = item.Id,
                    GameName = item.GameName,
                    MediaUrl= item.MediaUrl

                }).ToList()
            };
            

            return gamelist;
        }

        public UserDTO MyFavouritrGame(string UserId)
        {
            var game = Repository.GetAll<MyGame>().Where(u => u.Id == UserId && u.MyFavourite == true);
            var img = Repository.GetAll<GameMedium>().Where(i => i.InstructionType == 2 && i.Instruction == 1);
            var gametotal = Repository.GetAll<Game>();
            var mygame = game.Join(img, g => g.GameId, i => i.GameId, (g, s) => new { g.GameId, g.Id, s.MediaUrl });
            var z = mygame.Join(gametotal, mg => mg.GameId, gt => gt.GameId, (mg, gt) => new { gt.GameName, mg.MediaUrl, mg.Id, mg.GameId }).ToList();
            var gamelist= new UserDTO()
            {
                myfavourite = z.Select(item => new UserDTO.GameData
                {
                    Id = item.Id,
                    GameName = item.GameName,
                    MediaUrl = item.MediaUrl

                }).ToList()
            };

            return gamelist;
        }

        public UserDTO MyGameDetail(string GameName)
        {
            var game = Repository.GetAll<Game>().Where(g => g.GameName == GameName);
            var img = Repository.GetAll<GameMedium>().Where(i => i.InstructionType == 2 && i.Instruction == 1);
            var mygame = game.Join(img, g => g.GameId, i => i.GameId, (g, s) => new { g.GameIntroduction,g.ReleaseTime,g.Developer,g.Marker, s.MediaUrl });
            var gamedetail = new UserDTO()
            {
                GetGameDetails = mygame.Select(item => new UserDTO.GameDetail
                {
                    GameIntroduction = item.GameIntroduction,
                    MediaUrl = item.MediaUrl,
                    ReleaseTime = item.ReleaseTime,
                    Developer = item.Developer

                }).ToList()
            };
            return gamedetail;
        }

        public List<UserDTO> PrivacyList(string UserId)
        {
            throw new NotImplementedException();
        }

        //public List<UserDTO> PrivacyList(string UserId)
        //{
        //    var PrivacyPersonalFile = Repository.GetAll<UserPrivacy>().Where(p => p.PrivacyPersonalFile == UserPrivacyId);
        //    return privacylist;
        //}
    }
}
        



