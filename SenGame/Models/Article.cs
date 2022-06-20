using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class Article
    {
        public Article()
        {
            Likes = new HashSet<Like>();
            Replies = new HashSet<Reply>();
        }

        public int ArticleId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public string Check { get; set; }
        public string Title { get; set; }
        public int GameId { get; set; }
        public DateTime LastTime { get; set; }

        public virtual Game Game { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
