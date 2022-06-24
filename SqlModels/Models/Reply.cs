using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class Reply
    {
        public int ReplyId { get; set; }
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public string ReplyTitle { get; set; }
        public string ReplyText { get; set; }
        public int? ParentId { get; set; }
    }
}
