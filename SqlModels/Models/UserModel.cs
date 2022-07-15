using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SqlModels.Models
{
    public partial class UserModel:IdentityUser
    {
        public UserModel()
        {

            ArticleLikes = new HashSet<ArticleLike>();
            Articles = new HashSet<Article>();         
            CustomerServices = new HashSet<CustomerService>();
            FriendLists = new HashSet<FriendList>();
            Invites = new HashSet<Invite>();
            MyForums = new HashSet<MyForum>();
            MyGames = new HashSet<MyGame>();
            Replies = new HashSet<Reply>();
            ReplyLikes = new HashSet<ReplyLike>();
            ShoppingCarts = new HashSet<ShoppingCart>();
            UserPrivacies = new HashSet<UserPrivacy>();
            Wishes = new HashSet<Wish>();
        }

        public override string Id { get; set; }
        public int UserId { get; set; }
        public string Account { get; set; }
        public DateTime? EmailConfirmDate { get; set; }
        public string Address { get; set; }
        public string UserPicture { get; set; }
        public string UsernickName { get; set; }
        public int? UserCountryId { get; set; }
        public DateTime? CreateTime { get; set; }
        public string UserAbout { get; set; }
        public int? UserBackgroundId { get; set; }
        public int? OrderId { get; set; }
        public int PrivacyPersonalFile { get; set; }
        public int PrivacyGameFile { get; set; }
        public int PrivacyFriendsList { get; set; }
        public override string UserName { get; set; }
        public override string NormalizedUserName { get; set; }
        public override string Email { get; set; }
        public override string NormalizedEmail { get; set; }
        public override bool EmailConfirmed { get; set; }
        public override string PasswordHash { get; set; }
        public override string SecurityStamp { get; set; }
        public override string ConcurrencyStamp { get; set; }
        public override string PhoneNumber { get; set; }
        public override bool PhoneNumberConfirmed { get; set; }
        public override bool TwoFactorEnabled { get; set; }
        public override DateTimeOffset? LockoutEnd { get; set; }
        public override bool LockoutEnabled { get; set; }
        public override int AccessFailedCount { get; set; }

        public virtual Order Order { get; set; }
        public virtual UserCountry UserCountry { get; set; }
        public virtual ICollection<ArticleLike> ArticleLikes { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<CustomerService> CustomerServices { get; set; }
        public virtual ICollection<FriendList> FriendLists { get; set; }
        public virtual ICollection<Invite> Invites { get; set; }
        public virtual ICollection<MyForum> MyForums { get; set; }
        public virtual ICollection<MyGame> MyGames { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
        public virtual ICollection<ReplyLike> ReplyLikes { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public virtual ICollection<UserPrivacy> UserPrivacies { get; set; }
        public virtual ICollection<Wish> Wishes { get; set; }
        public virtual UserBackground UserBackground { get; set; }
        //public UserModel()
        //{
        //    ArticleLikes = new HashSet<ArticleLike>();
        //    Articles = new HashSet<Article>();
        //    //AspNetUserClaims = new HashSet<AspNetUserClaim>();
        //    //AspNetUserLogins = new HashSet<AspNetUserLogin>();
        //    //AspNetUserRoles = new HashSet<AspNetUserRole>();
        //    //AspNetUserTokens = new HashSet<AspNetUserToken>();
        //    Chats = new HashSet<Chat>();
        //    CustomerServices = new HashSet<CustomerService>();
        //    FriendLists = new HashSet<FriendList>();
        //    Invites = new HashSet<Invite>();
        //    MyForums = new HashSet<MyForum>();
        //    MyGames = new HashSet<MyGame>();
        //    Replies = new HashSet<Reply>();
        //    ReplyLikes = new HashSet<ReplyLike>();
        //    ShoppingCarts = new HashSet<ShoppingCart>();
        //    UserPrivacies = new HashSet<UserPrivacy>();
        //    Wishes = new HashSet<Wish>();
        //}
        //public int UserId { get; set; }
        //public string Account { get; set; }
        //public DateTime? EmailConfirmDate { get; set; }
        //public string Address { get; set; }
        //public string UserPicture { get; set; }
        //public string UsernickName { get; set; }
        //public int? UserCountryId { get; set; }
        //public DateTime? CreateTime { get; set; }
        //public string UserAbout { get; set; }
        //public int UserBackgroundId { get; set; }
        //public int? OrderId { get; set; }
        //public int PrivacyPersonalFile { get; set; }
        //public int PrivacyGameFile { get; set; }
        //public int PrivacyFriendsList { get; set; }

        //public virtual Order Order { get; set; }
        //public virtual UserCountry UserCountry { get; set; }
        //public virtual ICollection<ArticleLike> ArticleLikes { get; set; }
        //public virtual ICollection<Article> Articles { get; set; }
        ////public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        ////public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        ////public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
        ////public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
        //public virtual ICollection<Chat> Chats { get; set; }
        //public virtual ICollection<CustomerService> CustomerServices { get; set; }
        //public virtual ICollection<FriendList> FriendLists { get; set; }
        //public virtual ICollection<Invite> Invites { get; set; }
        //public virtual ICollection<MyForum> MyForums { get; set; }
        //public virtual ICollection<MyGame> MyGames { get; set; }
        //public virtual ICollection<Reply> Replies { get; set; }
        //public virtual ICollection<ReplyLike> ReplyLikes { get; set; }
        //public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
        //public virtual ICollection<UserPrivacy> UserPrivacies { get; set; }
        //public virtual ICollection<Wish> Wishes { get; set; }
    }
}
