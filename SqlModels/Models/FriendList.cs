using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class FriendList
    {
        public int FriendListId { get; set; }
        public string UserId { get; set; }
        public int? FriendGroupId { get; set; }
        public bool? IsBlockade { get; set; }

        public virtual UserModel User { get; set; }
    }
}
