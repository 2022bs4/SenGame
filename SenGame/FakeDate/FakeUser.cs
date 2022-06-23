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


    }
}
