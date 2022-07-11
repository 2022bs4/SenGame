using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class MyForum
    {
        public int MyForumId { get; set; }
        public string UserId { get; set; }
        public int ForumId { get; set; }
        public int? Sort { get; set; }

        public virtual Forum Forum { get; set; }
        public virtual UserModel User { get; set; }
    }
}
