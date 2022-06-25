using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SqlModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlModels.Data
{
    public class FakeUser : IdentityDbContext
    {
        public FakeUser(DbContextOptions<FakeUser> options)
            : base(options)
        {
        }

        //使用者
        //PassWord Address CreateDate
        //public DbSet<User> User { get; set; }
        //List<User> users = new List<User>()
        //{
        //    new User { UserId = 1, UserCountryId = 1, Account = "123456", Email="Rain@gmail.com", EmailConfirm = true, UsernickName = "張添宇", UserAbout = "早安你好", UserPicture = "https://memeprod.ap-south-1.linodeobjects.com/user-gif/fc83a3a705767ab42688e4e858777196.gif" , UserBackgroundId=2},
        //    new User { UserId = 2, UserCountryId = 1, Account = "456789", Email="Hand@gmail.com", EmailConfirm = true, UsernickName = "大帥哥", UserAbout = "午安你好", UserPicture = "https://memeprod.ap-south-1.linodeobjects.com/user-gif-post/1654151736656.gif", UserBackgroundId=1},
        //    new User { UserId = 3, UserCountryId = 1, Account = "789123", Email="AKAQ@gmail.com", EmailConfirm = true, UsernickName = "AKA", UserAbout = "晚安你好", UserPicture = "https://memeprod.ap-south-1.linodeobjects.com/user-gif-thumbnail/d4dd77bf2820f1c7c7b43121d4f7477b.gif" , UserBackgroundId=3}
        //};


        //願望清單
        //public DbSet<Wish> Wish { get; set; }
        //List<Wish> wishes = new List<Wish>
        //{
        //    new Wish { WishId = 0, UserId = 0, GameId = 0, AddTime = new DateTime(2022, 06, 22, 12, 04, 12) },
        //    new Wish { WishId = 1, UserId = 1, GameId = 1, AddTime = new DateTime(2022, 06, 22, 12, 04, 12) },
        //    new Wish { WishId = 2, UserId = 2, GameId = 2, AddTime = new DateTime(2022, 06, 22, 12, 04, 12) }
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
