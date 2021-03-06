using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class Reply
    {
        public Reply()
        {
            ReplyLikes = new HashSet<ReplyLike>();
        }

        public int ReplyId { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public string ReplyTitle { get; set; }
        public string ReplyText { get; set; }
        public int? ParentId { get; set; }

        public virtual Article Article { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<ReplyLike> ReplyLikes { get; set; }
    }
}
