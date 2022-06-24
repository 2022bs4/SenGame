using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class Forum
    {
        public int ForumId { get; set; }
        public string Name { get; set; }
        public string Banner { get; set; }
        public int? GameId { get; set; }
    }
}
