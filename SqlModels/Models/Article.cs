using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class Article
    {
        public Article()
        {
            ArticleLikes = new HashSet<ArticleLike>();
            Replies = new HashSet<Reply>();
        }

        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime PostTime { get; set; }
        public string Title { get; set; }
        public int ForumId { get; set; }
        public DateTime LastReplyTime { get; set; }
        public int ArticleTagId { get; set; }

        public virtual ArticleTag ArticleTag { get; set; }
        public virtual Forum Forum { get; set; }
        public virtual AspNetUser User { get; set; }
        public virtual ICollection<ArticleLike> ArticleLikes { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
