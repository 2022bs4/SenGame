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

        public List<UserDTO> MyGameList(string UserId)
        {
            var game = Repository.GetAll<MyGame>().Where(u => u.Id == UserId);
            var img = Repository.GetAll<GameMedium>().Where(i => i.InstructionType == 2 && i.Instruction == 1);
            var gametotal = Repository.GetAll<Game>();
            var mygame = game.Join(img, g => g.GameId, i => i.GameId, (g, s) => new { g.GameId, g.Id, s.MediaUrl });
            var z = mygame.Join(gametotal, mg => mg.GameId, gt => gt.GameId, (mg, gt) => new { gt.GameName, mg.MediaUrl, mg.Id, mg.GameId });
            var gamelist = new List<UserDTO>();
            //foreach(var item in z)
            //{
            //    gamelist.Add(new UserDTO.GameData
            //    {
            //        Id = item.Id,
            //        GameName = item.GameName,
            //        MediaUrl = item.MediaUrl,
            //    }).ToList();
            //}
            
           
            return gamelist;
        }
    }
}
