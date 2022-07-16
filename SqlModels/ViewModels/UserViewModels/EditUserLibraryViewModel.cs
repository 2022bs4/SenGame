using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModels.ViewModels.UserViewModels
{
    public class EditUserLibraryViewModel
    {
        //Tag Helper
        public string UserCountry { get; set; }
        public List<SelectListItem> UserCountryies { get; } = new List<SelectListItem>
        {
            new SelectListItem{Text = "不顯示", Value="1"},
            new SelectListItem{Text = "帕拉迪島", Value="2"},
            new SelectListItem{Text = "卡加布列島", Value="3"},
            new SelectListItem{Text = "黎明島", Value="4"}
        };

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
    }
}
