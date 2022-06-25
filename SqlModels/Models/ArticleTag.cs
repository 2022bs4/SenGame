using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class ArticleTag
    {
        public ArticleTag()
        {
            Articles = new HashSet<Article>();
        }

        public int ArticleTagId { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
