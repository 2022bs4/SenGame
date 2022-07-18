using AutoMapper;
using Services.Interface;
using SqlModels.DTOModels;
using SqlModels.Models;
using SqlModels.Repository.Interface;
using System.Collections.Generic;
using System.Linq;


namespace Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

        //-------------------------從這裡開始是 明翰 的OOOOOOOOOOOOO-----------------------------------

        public UserDTO UncategorizedGame(string UserId)
        {
            //uncategorized 未分類
            //my favourite  我的最愛

          
            var uncategorized = Repository.GetAll<MyGame>();
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
                    MediaUrl = item.MediaUrl

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
            var pic= Repository.GetAll<GameMedium>().Where(i => i.InstructionType == 1 && i.Instruction == 1);
            var swipersimg = game.Join(pic, g => g.GameId, p => p.GameId, (g, s) => new { s.MediaUrl });
            var mygame = game.Join(img, g => g.GameId, i => i.GameId, (g, s) => new { g.GameIntroduction,g.ReleaseTime,g.Developer,g.Marker, s.MediaUrl });
            var gamedetail = new UserDTO()
            {
                GetGameDetails = mygame.Select(item => new UserDTO.GameDetail
                {
                    GameIntroduction = item.GameIntroduction,
                    MediaUrl = item.MediaUrl,
                    ReleaseTime = item.ReleaseTime,
                    Developer = item.Developer,
                    Marker  = item.Marker,
                    GameSwipers = swipersimg.Select(item => new UserDTO.GameDetail.GameSwiper
                    {
                        MediaUrl = item.MediaUrl,
                    }).ToList()

                }).ToList()
            };
            return gamedetail;
        }

        //-------------------------從這裡結束是 明翰 的OOOOOOOOOOOOO-----------------------------------


        //-------------------------從這裡開始是 璇   的OOOOOOOOOOOOO-----------------------------------


        public OutputUserDTO PrivacyList(string userId, int personId, int friendId, int gameId)
        { 
            var updata = Repository.FindBy<UserModel>(x => x.Id == userId).First();
            OutputUserDTO result = new OutputUserDTO();
            try
            {
                updata.PrivacyPersonalFile = personId;
                updata.PrivacyGameFile = gameId;
                updata.PrivacyFriendsList = friendId;

                Update<UserModel>(updata);
                result.message = "您的隱私設定已更改成功";
            }
            catch
            { 
                result.message = "您的設定更改失敗";
            }



            return result;
        }

        //我的個人檔案隱私
        //public prypersonalInputUserDTO prypersonalFile(string userId, int status)
        //{
        //    var personalList = Repository.FindBy<UserModel>(x => x.Id == userId).FirstOrDefault();
        //    personalList.PrivacyPersonalFile = status;

        //    Repository.Update<UserModel>(personalList);

        //    var result1 = new prypersonalInputUserDTO();
        //    return result1;
        //}
        ////遊戲資料隱私
        //public prygameInputUserDTO prygameFile(string userId, int status)
        //{
        //    var gameList = Repository.FindBy<UserModel>(x => x.Id == userId).FirstOrDefault();
        //    gameList.PrivacyGameFile = status;

        //    Repository.Update<UserModel>(gameList);

        //    var result2 = new prygameInputUserDTO();
        //    return result2;
        //}

        ////好友隱私設定
        //public InputUserDTO test(string userId , int status)
        //{
        //    var frindList = Repository.FindBy<UserModel>(x => x.Id == userId).FirstOrDefault();

        //    frindList.PrivacyFriendsList = status;
        //    //試試看下斷點
        //    Repository.Update<UserModel>(frindList);
        //    Repository.SaveChanges();
        //    //var test
        //    var result = new InputUserDTO();
        //    return result;
        //}

        //-------------------------從這裡結束是 璇   的OOOOOOOOOOOOO-----------------------------------



        //-------------------------從這裡開始是 君君   的OOOOOOOOOOOOO-----------------------------------

    }
}
        



