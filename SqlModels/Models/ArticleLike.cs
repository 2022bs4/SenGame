using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class ArticleLike
    {
        public int LikeId { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
        public virtual User User { get; set; }
    }
}
