using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SenGame.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenGame.Data
{
    public class FakeUser : IdentityDbContext
    {
        public FakeUser(DbContextOptions<FakeUser> options)
            : base(options)
        {
        }

        public DbSet<SenGame.Models.User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder FakeUser)
        {
            //List<User> users = new List<User>();
            //{
            //    new User { UserId = 1, UsernickName="1哈哈是我啦" , UserAbout="早安你好", UserPicture="網址" ,UserCountryId=1},
            //    new User { UserId = 2, UsernickName = "2哈哈是我啦", UserAbout = "午安你好", UserPicture = "網址", UserCountryId = 3 },
            //    new User { UserId = 3, UsernickName = "3哈哈是我啦", UserAbout = "晚安你好", UserPicture = "網址", UserCountryId = 2 }
            //};
        }

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
