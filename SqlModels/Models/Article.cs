using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class Article
    {
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public string ArticleContent { get; set; }
        public DateTime PostDate { get; set; }
        public string Title { get; set; }
        public int ForumId { get; set; }
        public DateTime LastReplyTime { get; set; }
        public int ArticleTagId { get; set; }
    }
}
