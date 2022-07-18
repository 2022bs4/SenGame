using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace SqlModels.ViewModels.UserViewModels
{
    
    public class PrivacieLibraryViewModel
    {
        //[Required]

        //Tag Helper
        public string Privacie { get; set; }
        public List<SelectListItem> Privacies { get; } = new List<SelectListItem>
        {
            new SelectListItem{Text = "公開", Value="public"},
            new SelectListItem{Text = "僅限好友", Value="Friendsonly"},
            new SelectListItem{Text = "私人", Value="personal"}
        };

        //
        public List<PrivacieData> PrivacieList { get; set; }
        
        public class PrivacieData
        {
            [Display (Name = "我的個人檔案 隱私設定:")]
            public int PrivacyPersonalFile { get; set; } //個人檔案 隱私設定

            [Display(Name = "遊戲資料 隱私設定:")]
            public int PrivacyGameFile { get; set; }     //遊戲資料 隱私設定

            [Display(Name = "好友名單 隱私設定:")]
            public int PrivacyFriendsList { get; set; }  //好友名單 隱私設定
        }
    }
}
