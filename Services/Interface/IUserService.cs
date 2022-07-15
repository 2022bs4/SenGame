using SqlModels.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IUserService : IBaseService
    {
        //public List<UserDTO> MyGameList(string UserId);
        public List<UserDTO> PrivacyList(string UserId);
        //未分類遊戲
        public UserDTO UncategorizedGame(string UserId);
        //我的最愛遊戲
        public UserDTO MyFavouritrGame(string UserId);
        //選到的遊戲加載
        public UserDTO MyGameDetail(string GameName);
    }
}
