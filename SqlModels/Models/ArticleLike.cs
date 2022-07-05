using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class ArticleLike
    {
        public int LikeId { get; set; }
        public string UserId { get; set; }
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
        public virtual UserModel User { get; set; }
    }
}
