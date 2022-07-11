using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class Usergroup
    {
        public int UserGroupId { get; set; }
        public string UserId { get; set; }
        public int FriendGroupId { get; set; }

        public virtual FriendGroup FriendGroup { get; set; }
        public virtual UserModel User { get; set; }
    }
}
