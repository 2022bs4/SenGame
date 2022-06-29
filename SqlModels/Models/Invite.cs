using System;
using System.Collections.Generic;

#nullable disable

namespace SqlModels.Models
{
    public partial class Invite
    {
        public int InviteId { get; set; }
        public int UserId { get; set; }
        public int SenderId { get; set; }
        public string Message { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
