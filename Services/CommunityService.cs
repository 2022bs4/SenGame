using Services.Interface;
using SqlModels.DTOModels;
using SqlModels.Models;
using SqlModels.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
namespace Services
{
    public class CommunityService : BaseService<Forum>, ICommunityService
    {
 

        public CommunityService(
            IRepository<Forum> repository,
            IRepository<MyForum> myForum, 
            IRepository<UserModel> user,
            IRepository<GameMedium> gamemedium,
            IRepository<Game> game) : base(repository)
        {
            this._myForum = myForum;
            this._user = user;
            this._game = game;
            this._gamemedium = gamemedium;
        }
        public IEnumerable<Forum> GetUserForum(string _name)
        {
            var id = _user.GetAll().First(x => x.UserName == _name).UserId;
            var ids = _myForum.FindBy(x => x.UserId == id.ToString()).Select(x => x.ForumId);
            List<Forum> data = new();
            foreach (var item in ids)
            {
                data.Add(_repository.GetById(item));
            }
            return data.AsEnumerable();
        }

        public List<CommunityDTO> Article()
        {
            var game = _game.GetAll();
            var gamemedium = _gamemedium.GetAll().Where(i => i.InstructionType == 2 && i.Instruction == 1);
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
            var img = _gamemedium.GetAll().Where(g => g.Instruction == 1 && g.InstructionType == 1);
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
