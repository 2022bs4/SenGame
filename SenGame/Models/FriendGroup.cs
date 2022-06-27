using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class FriendGroup
    {
        public int FriendGoupId { get; set; }
        public string GroupName { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
