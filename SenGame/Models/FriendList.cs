using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class FriendList
    {
        public FriendList()
        {
            MemderReplies = new HashSet<MemderReply>();
        }

        public int UserId { get; set; }
        public int FriendListId { get; set; }
        public int FriendId { get; set; }
        public int? FriendGroupId { get; set; }
        public string FriendNickName { get; set; }
        public bool? IsBlockade { get; set; }

        public virtual User Friend { get; set; }
        public virtual FriendGroup FriendListNavigation { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<MemderReply> MemderReplies { get; set; }
    }
}
