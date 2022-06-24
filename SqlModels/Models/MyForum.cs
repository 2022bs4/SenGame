using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class MyForum
    {
        public int UserId { get; set; }
        public int ForumId { get; set; }
        public int MyForumId { get; set; }
    }
}
