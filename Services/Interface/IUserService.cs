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
        //-------------------------從這裡開始是 明翰 的OOOOOOOOOOOOO-----------------------------------

        //未分類遊戲
        public UserDTO UncategorizedGame(string UserId);
        //我的最愛遊戲
        public UserDTO MyFavouritrGame(string UserId);
        //選到的遊戲加載
        public UserDTO MyGameDetail(string GameName);
        //-------------------------從這裡結束是 明翰 的OOOOOOOOOOOOO-----------------------------------


        //-------------------------從這裡開始是 璇   的OOOOOOOOOOOOO-----------------------------------

        public List<UserDTO> PrivacyList(string UserId);
        //璇的隱私狀態
        public InputUserDTO test(string userId, int status);

        //-------------------------從這裡結束是 璇   的OOOOOOOOOOOOO-----------------------------------

        //-------------------------從這裡開始是 君君   的OOOOOOOOOOOOO-----------------------------------

    }
}
