using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SenGame.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenGame.Data
{
    public class FakeUserDBContext : IdentityDbContext
    {
        public FakeUserDBContext(DbContextOptions<FakeUserDBContext> options)
            : base(options)
        {
        }

        public DbSet<SenGame.Models.User> User { get; set; }

        List<User> users = new List<User>
        {
            new User { UserId = 1, UsernickName = "", Account="", Address="", UserAbout=""}
        };
    }
}
