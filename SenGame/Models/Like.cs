using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class Like
    {
        public int LikeId { get; set; }
        public int UserId { get; set; }
        public int Article { get; set; }

        public virtual Article ArticleNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
