using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interface;
using SqlModels.DTOModels;
using SqlModels.Models;
using SqlModels.Repository.Interface;


namespace Services.CommunityService
{
    public class CommunityService : BaseService<Forum>, ICommunityService
    {
        private readonly IRepository<Game> _game;
        private readonly IRepository<GameMedium> _gamemedium;
        public CommunityService(IRepository<Forum> repository, IRepository<GameMedium> gamemedium, IRepository<Game> game)
        : base(repository)
        {
            _game = game;
            _gamemedium = gamemedium;
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
