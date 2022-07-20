using SqlModels.DTOModels;
using SqlModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SqlModels.DTOModels.UserDTO;

namespace Services.Interface
{
    public interface IUserService : IBaseService
    {
        //-------------------------從這裡開始是 明翰 的OOOOOOOOOOOOO-----------------------------------

        //未分類遊戲
        public UserDTO UncategorizedGame(string UserId);
        //我的最愛遊戲
        public UserDTO MyFavouritrGame(string UserId);
        //選到的遊戲加載
        public UserDTO MyGameDetail(string GameName);
        //修改遊戲是否為我的最愛
        public void EditMyGame(string UserId,string mygmaelibrary,bool myfavourite);

        //-------------------------從這裡結束是 明翰 的OOOOOOOOOOOOO-----------------------------------


        //-------------------------從這裡開始是 璇   的OOOOOOOOOOOOO-----------------------------------

        public OutputUserDTO PrivacyList(string userId,int personId, int friendId, int gameId);

        //我的個人檔案隱私
        //public prypersonalInputUserDTO prypersonalFile(string userId, int status);
        ////遊戲資料隱私
        //public prygameInputUserDTO prygameFile(string userId, int status);
        ////好友隱私設定
        //public InputUserDTO test(string userId, int status);

        //-------------------------從這裡結束是 璇   的OOOOOOOOOOOOO-----------------------------------

        //-------------------------從這裡開始是 君君   的OOOOOOOOOOOOO-----------------------------------

    }
}
