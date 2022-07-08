using Services.Interface;
using SqlModels.DTOModels;
using SqlModels.Models;
using SqlModels.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
namespace Services
{
    public class CommunityService : BaseService, ICommunityService
    {
        public CommunityService(IRepository repository) : base(repository)
        {
        }
        public IQueryable<Forum> GetUserForum(string _name)
        {
            var id = Repository.FindBy<UserModel>(x => x.UserName == _name).First().UserId;
            var ids = Repository.FindBy<MyForum>(x => x.UserId == id.ToString()).Select(x => x.ForumId);
            var data = Repository.FindBy<Forum>(x => ids.Contains(x.ForumId));
            return data;
        }

        public List<CommunityDTO> Article()
        {
            var game = Repository.GetAll<Game>();
            var gamemedium = Repository.GetAll<GameMedium>().Where(i => i.InstructionType == 2 && i.Instruction == 1);
            var article = game.Join(gamemedium, g => g.GameId, i => i.GameId, (g, s) => new { g.GameId, s.MediaUrl, g.GameName, g.GameIntroduction });

            var articlelist = new List<CommunityDTO>();
            foreach (var item in article)
            {
                articlelist.Add(new CommunityDTO
                {
                    GameId = item.GameId,
                    GameName = item.GameName,
                    GameIntroduction = item.GameIntroduction,
                    MediaUrl = item.MediaUrl

                });
            }
            return articlelist;
        }



        public List<Swipers> Swipers()
        {
            var img = Repository.GetAll<GameMedium>().Where(g => g.Instruction == 1 && g.InstructionType == 1);
            var swipers = new List<Swipers>();
            foreach (var item in img)
            {
                swipers.Add(new Swipers
                {
                    MediaUrl = item.MediaUrl
                });
            }
            return swipers;
        }

    }
}
