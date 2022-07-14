using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.DTOModels
{
    public class UserDTO
    {   
        public  List<GameData> gamelist { get;set; }
        
        public class GameData
        {
            public string Id { get; set; }
            public string GameName { get; set; }
            public string GameIntroduction { get; set; }
            public string MediaUrl { get; set; }
        }

        public List<PrivacieData> PrivacieList { get; set; }
        public class PrivacieData
        {
            public string Id { get; set; }

            [Display(Name = "我的個人檔案 隱私設定:")]
            public int PrivacyPersonalFile { get; set; } //個人檔案 隱私設定

            [Display(Name = "遊戲資料 隱私設定:")]
            public int PrivacyGameFile { get; set; }     //遊戲資料 隱私設定

            [Display(Name = "好友名單 隱私設定:")]
            public int PrivacyFriendsList { get; set; }  //好友名單 隱私設定
        }
    }
}
