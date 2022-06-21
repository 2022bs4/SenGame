using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class MemderReply
    {
        public int MemderReplyId { get; set; }
        public string ReplyContent { get; set; }
        public int UserId { get; set; }
        public DateTime? ReplyDate { get; set; }
        public int FriendId { get; set; }
        public int? ParentId { get; set; }

        public virtual FriendList Friend { get; set; }
        public virtual User User { get; set; }
    }
}
