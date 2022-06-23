using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SenGame.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SenGame.Data
{
    public class FakeUser : IdentityDbContext
    {
        public FakeUser(DbContextOptions<FakeUser> options)
            : base(options)
        {
        }

        //使用者
        //public DbSet<User> User { get; set; }
        //List<User> users = new List<User>()
        //{
        //    new User { UserId = 1, UserCountryId = 1, Account = "123456", Email="Rain@gmail.com", EmailConfirm = true, PassWord="123", Address="台南市安平區", UsernickName = "張添宇", UserAbout = "早安你好", UserPicture = "https://memeprod.ap-south-1.linodeobjects.com/user-gif/fc83a3a705767ab42688e4e858777196.gif" , UserBackgroundId = 2, CreateTime= null , OrderId=1, PrivacyPersonalFile=2, PrivacyGameFile=3, PrivacyFriendsList=2},
        //    new User { UserId = 2, UserCountryId = 1, Account = "456789", Email="Hand@gmail.com", EmailConfirm = true, PassWord="456", Address="台北市大安區", UsernickName = "大帥哥", UserAbout = "午安你好", UserPicture = "https://memeprod.ap-south-1.linodeobjects.com/user-gif-post/1654151736656.gif", UserBackgroundId = 1, CreateTime= null, OrderId=2, PrivacyPersonalFile=1, PrivacyGameFile=3, PrivacyFriendsList=1},
        //    new User { UserId = 3, UserCountryId = 1, Account = "789123", Email="AKAQ@gmail.com", EmailConfirm = true, PassWord="789", Address="新竹市香山區", UsernickName = "AKA", UserAbout = "晚安你好", UserPicture = "https://memeprod.ap-south-1.linodeobjects.com/user-gif-thumbnail/d4dd77bf2820f1c7c7b43121d4f7477b.gif" , UserBackgroundId = 3, CreateTime= null, OrderId=3, PrivacyPersonalFile=3, PrivacyGameFile=1, PrivacyFriendsList=2}
        //};

        //使用者主頁背景
        //https://webgradients.com/
        //public DbSet<UserBackground> UserBackground { get; set; }

        //List<UserBackground> UserBackgrounds = new List<UserBackground>()
        //{
        //    //background-image: linear-gradient(to top, #fad0c4 0%, #ffd1ff 100%);
        //    new UserBackground { UserBackgroundId = 1, BackgroundColor="003春暖花開"},
        //    //background-image: linear-gradient(to top, #fbc2eb 0%, #a6c1ee 100%);
        //    new UserBackground { UserBackgroundId = 2, BackgroundColor="008多雨的阿什維爾"},
        //    //background-image: linear-gradient(120deg, #84fab0 0%, #8fd3f4 100%);
        //    new UserBackground { UserBackgroundId = 3, BackgroundColor="012 誘人的蔚藍"},
        //    //background-image: linear-gradient(120deg, #e0c3fc 0%, #8ec5fc 100%);
        //    new UserBackground { UserBackgroundId = 4, BackgroundColor="016深藍"},
        //    //background-image: linear-gradient(to top, #a8edea 0%, #fed6e3 100%);
        //    new UserBackground { UserBackgroundId = 5, BackgroundColor="023 稀有風"},
        //    //background-image: linear-gradient(to right, #eea2a2 0%, #bbc1bf 19%, #57c6e1 42%, #b49fda 79%, #7ac5d8 100%);
        //    new UserBackground { UserBackgroundId = 6, BackgroundColor="044 害羞的彩虹"}
        //};

        //使用者國家
        //public DbSet<UserCountry> UserCountry { get; set; }
        //List<UserCountry> UserCountrys = new List<UserCountry>()
        //{
        //    new UserCountry{UserCountryId = 1, CountryName = "台灣" },
        //    new UserCountry{UserCountryId = 2, CountryName = "卡加布列島" },
        //    new UserCountry{UserCountryId = 3, CountryName = "艾爾迪亞帝國" },
        //    new UserCountry{UserCountryId = 3, CountryName = "瑪雷帝國" },
        //};

        //使用者隱私狀態
        //public DbSet<UserPrivacy> UserPrivacy { get; set; }
        //List<UserPrivacy> UserPrivacyState = new List<UserPrivacy>()
        //{
        //    new UserPrivacy{UserPrivacyId = 1, PrivacyState = "公開" },
        //    new UserPrivacy{UserPrivacyId = 2, PrivacyState = "只限好友" },
        //    new UserPrivacy{UserPrivacyId = 3, PrivacyState = "不公開" },
        //};

        //願望清單
        //public DbSet<Wish> Wish { get; set; }
        //List<Wish> wishes = new List<Wish>
        //{
        //    new Wish { WishId = 0, UserId = 0, GameId = 0, AddDate = DateTime.Now },
        //    new Wish { WishId = 1, UserId = 1, GameId = 1, AddDate = DateTime.Now },
        //    new Wish { WishId = 2, UserId = 2, GameId = 2, AddDate = DateTime.Now }
        //};

        //邀請
        //public DbSet<Invite> Invit { get; set; }
        //List<Invite> invites = new List<Invite>
        //{
        //    new Invite { InviteId = 0, UserId = 0, SenderId = 0 , Message = "此人申請為您好友"},
        //    new Invite { InviteId = 1, UserId = 1, SenderId = 1 , Message = "收到邀請通知"},
        //    new Invite { InviteId = 2, UserId = 2, SenderId = 2 , Message = "邀請訊息!!!"},
        //};


    }
}
