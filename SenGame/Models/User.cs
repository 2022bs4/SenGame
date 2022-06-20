using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class User
    {
        public User()
        {
            Chats = new HashSet<Chat>();
            FriendListFriends = new HashSet<FriendList>();
            FriendListUsers = new HashSet<FriendList>();
            InviteSends = new HashSet<Invite>();
            InviteUsers = new HashSet<Invite>();
            Likes = new HashSet<Like>();
            MyForums = new HashSet<MyForum>();
            MyGames = new HashSet<MyGame>();
            Replies = new HashSet<Reply>();
            ReplyLikes = new HashSet<ReplyLike>();
            Wishes = new HashSet<Wish>();
        }

        public int UserId { get; set; }
        public int PayId { get; set; }
        public string Email { get; set; }
        public bool EmailConfirm { get; set; }
        public string PassWordTest { get; set; }
        public string PassWord { get; set; }
        public string Address { get; set; }
        public string UserPicture { get; set; }
        public string UserUrl { get; set; }
        public string UsernickName { get; set; }
        public int? UserCountryId { get; set; }

        public virtual Visa Pay { get; set; }
        public virtual UserCountry UserCountry { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<FriendList> FriendListFriends { get; set; }
        public virtual ICollection<FriendList> FriendListUsers { get; set; }
        public virtual ICollection<Invite> InviteSends { get; set; }
        public virtual ICollection<Invite> InviteUsers { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<MyForum> MyForums { get; set; }
        public virtual ICollection<MyGame> MyGames { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
        public virtual ICollection<ReplyLike> ReplyLikes { get; set; }
        public virtual ICollection<Wish> Wishes { get; set; }
    }
}
