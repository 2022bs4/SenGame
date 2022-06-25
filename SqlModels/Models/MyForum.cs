using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class MyForum
    {
        public int MyForumId { get; set; }
        public int UserId { get; set; }
        public int ForumId { get; set; }

        public virtual Forum Forum { get; set; }
    }
}
