using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class ReplyLike
    {
        public int ReplyLikeId { get; set; }
        public int ReplyId { get; set; }
        public int UserId { get; set; }

        public virtual Reply Reply { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
