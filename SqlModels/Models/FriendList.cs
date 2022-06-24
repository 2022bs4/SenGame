using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class FriendList
    {
        public int UserId { get; set; }
        public int FriendListId { get; set; }
        public int FriendId { get; set; }
        public int? FriendGroupId { get; set; }
        public string FriendNickName { get; set; }
        public bool? IsBlockade { get; set; }
    }
}
