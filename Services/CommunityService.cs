using Services.Interface;
using SqlModels.DTOModels;
using SqlModels.DTOModels.Community;
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
        public List<ForumDTO> GetForums()
        {
            var data = Repository.GetAll<Forum>().Select(i=> new ForumDTO()
            {
                Id = i.ForumId,
                Name =i.Name,
                Banner = i.Banner
            }).ToList();
            return data;
        }
        public List<ForumDTO> GetForums(string name)
        {
            var forumIds = Repository.FindBy<MyForum>(x => x.UserId == this.GetUserId(name)).Select(i => i.MyForumId);
            var data = Repository.FindBy<Forum>(x => forumIds.Contains(x.ForumId)).Select(i => new ForumDTO()
            {
                Id = i.ForumId,
                Name = i.Name,
                Banner = i.Banner
            }).ToList(); ;
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
        //把User.Identity.Name轉成id
        public string GetUserId(string name)
        {
            var id = Repository.GetAll<UserModel>().First(x => x.UserName == name).Id;
            return id;
        }

    }
}
