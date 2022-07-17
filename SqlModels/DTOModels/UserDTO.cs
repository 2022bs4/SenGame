using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SqlModels.ViewModels.UserViewModels.EditUserLibraryViewModel;

namespace SqlModels.DTOModels
{
    //-------------------------從這裡開始是 明翰 的OOOOOOOOOOOOO-----------------------------------

    public class UserDTO
    {   
        //我的遊戲庫的所有的遊戲集合(未分類)
        public  List<GameData> gamelist { get;set; }
        //我的遊戲庫的所有的遊戲集合(我的最愛)
        public List<GameData> myfavourite { get; set; }
        //選到的遊戲
        public List<GameDetail> GetGameDetails { get; set; }

        public class GameData
        {
            public string Id { get; set; }
            public string GameName { get; set; }
            public string GameIntroduction { get; set; }
            public string MediaUrl { get; set; }
        }
        //回傳字串到service裡面
        public class Game_Name
        {
            public string GameName { get; set; }
        }

        public class GameDetail
        {
            public string GameName { get; set; }
            public string GameIntroduction { get; set; }
            public DateTime ReleaseTime { get; set; }
            public string Developer { get; set; }
            public string Marker { get; set; }
            public string MediaUrl { get; set; }
            public List<GameSwiper> GameSwipers{ get; set; }

            public class GameSwiper
            {
                public string MediaUrl { get; set; }
            }
        }

        public List<EditUserData> EditUserList { get; set; }
        public class EditUserData
        {
            [Display(Name = "我的個人檔案名稱 :")]
            public string UserName { get; set; }

            [Display(Name = "國家 / 地區")]
            public int UserCountryId { get; set; }

            [Display(Name = "關於我 :")]
            public string UserAbout { get; set; }
        }

        public List<PrivacieData> PrivacieList { get; set; }
        public class PrivacieData
        {
            public string Id { get; set; }

            //[Display(Name = "我的個人檔案 隱私設定:")]
            public int PrivacyPersonalFile { get; set; } //個人檔案 隱私設定

            //[Display(Name = "遊戲資料 隱私設定:")]
            public int PrivacyGameFile { get; set; }     //遊戲資料 隱私設定

            //[Display(Name = "好友名單 隱私設定:")]
            public int PrivacyFriendsList { get; set; }  //好友名單 隱私設定
        }
    }
    //-------------------------從這裡結束是 明翰 的OOOOOOOOOOOOO-----------------------------------


    //-------------------------從這裡開始是 璇   的OOOOOOOOOOOOO-----------------------------------

    public class OutputUserDTO
    {
        public int UserPrivacyId { get; set; }
        
    }
    public class InputUserDTO
    {
        public string UserPrivacyName{ get; set; }
    }

    //-------------------------從這裡結束是 璇   的OOOOOOOOOOOOO-----------------------------------


    //-------------------------從這裡開始是 君君   的OOOOOOOOOOOOO-----------------------------------

}
