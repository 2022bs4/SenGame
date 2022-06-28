using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            ArticleLikes = new HashSet<ArticleLike>();
            Articles = new HashSet<Article>();
            Chats = new HashSet<Chat>();
            FriendLists = new HashSet<FriendList>();
            Invites = new HashSet<Invite>();
            MyForums = new HashSet<MyForum>();
            MyGames = new HashSet<MyGame>();
            Replies = new HashSet<Reply>();
            ReplyLikes = new HashSet<ReplyLike>();
            ShoppingCarts = new HashSet<ShoppingCart>();
            UserPrivacies = new HashSet<UserPrivacy>();
        }

        public string Id { get; set; }
        public int UserId { get; set; }
        public string Account { get; set; }
        public DateTime? EmailConfirmDate { get; set; }
        public string Address { get; set; }
        public string UserPicture { get; set; }
        public string UsernickName { get; set; }
        public int? UserCountryId { get; set; }
        public DateTime? CreateTime { get; set; }
        public string UserAbout { get; set; }
        public int UserBackgroundId { get; set; }
        public int? OrderId { get; set; }
        public int PrivacyPersonalFile { get; set; }
        public int PrivacyGameFile { get; set; }
        public int PrivacyFriendsList { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual Order Order { get; set; }
        public virtual UserBackground UserBackground { get; set; }
        public virtual UserCountry UserCountry { get; set; }
        public virtual ICollection<ArticleLike> ArticleLikes { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<FriendList> FriendLists { get; set; }
        public virtual ICollection<Invite> Invites { get; set; }
        public virtual ICollection<MyForum> MyForums { get; set; }
        public virtual ICollection<MyGame> MyGames { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
        public virtual ICollection<ReplyLike> ReplyLikes { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public virtual ICollection<UserPrivacy> UserPrivacies { get; set; }
    }
}
