using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class Chat
    {
        public int ChatId { get; set; }
        public string UserId { get; set; }
        public int FriendChatId { get; set; }
        public virtual FriendChat FriendChat { get; set; }
        public virtual UserModel User { get; set; }
    }
}
