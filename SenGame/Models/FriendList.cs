using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class FriendList
    {
        public FriendList()
        {
            Chats = new HashSet<Chat>();
        }

        public int FriendListId { get; set; }
        public int UserId { get; set; }
        public string GroupName { get; set; }
        public bool BlockadeList { get; set; }
        public int? FriendId { get; set; }

        public virtual User Friend { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
    }
}
