using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class User
    {
        public User()
        {
            ArticleLikes = new HashSet<ArticleLike>();
            Chats = new HashSet<Chat>();
            FriendGroups = new HashSet<FriendGroup>();
            InviteSenders = new HashSet<Invite>();
            InviteUsers = new HashSet<Invite>();
            MyForums = new HashSet<MyForum>();
            MyGames = new HashSet<MyGame>();
            Replies = new HashSet<Reply>();
            ReplyLikes = new HashSet<ReplyLike>();
            UserPrivacies = new HashSet<UserPrivacy>();
            Wishes = new HashSet<Wish>();
        }

        public int UserId { get; set; }
        public string Account { get; set; }
        public string Email { get; set; }
        public bool EmailConfirm { get; set; }
        public DateTime? EmailConfirmDate { get; set; }
        public string PassWord { get; set; }
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

        public virtual Order Order { get; set; }
        public virtual UserBackground UserBackground { get; set; }
        public virtual UserCountry UserCountry { get; set; }
        public virtual ICollection<ArticleLike> ArticleLikes { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<FriendGroup> FriendGroups { get; set; }
        public virtual ICollection<Invite> InviteSenders { get; set; }
        public virtual ICollection<Invite> InviteUsers { get; set; }
        public virtual ICollection<MyForum> MyForums { get; set; }
        public virtual ICollection<MyGame> MyGames { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
        public virtual ICollection<ReplyLike> ReplyLikes { get; set; }
        public virtual ICollection<UserPrivacy> UserPrivacies { get; set; }
        public virtual ICollection<Wish> Wishes { get; set; }
    }
}
