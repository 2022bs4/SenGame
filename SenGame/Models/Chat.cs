using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class Chat
    {
        public int? UserId { get; set; }
        public int? FriendListId { get; set; }
        public DateTime? ChatDate { get; set; }
        public string ChatContext { get; set; }
        public int Chatid { get; set; }

        public virtual FriendList FriendList { get; set; }
        public virtual User User { get; set; }
    }
}
