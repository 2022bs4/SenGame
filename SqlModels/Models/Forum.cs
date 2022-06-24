using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class Forum
    {
        public Forum()
        {
            Articles = new HashSet<Article>();
            MyForums = new HashSet<MyForum>();
        }

        public int ForumId { get; set; }
        public string Name { get; set; }
        public string Banner { get; set; }
        public int? GameId { get; set; }

        public virtual Game Game { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<MyForum> MyForums { get; set; }
    }
}
