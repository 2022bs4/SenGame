using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class Invite
    {
        public int InviteId { get; set; }
        public int UserId { get; set; }
        public int SendId { get; set; }
        public string Message { get; set; }

        public virtual User Send { get; set; }
        public virtual User User { get; set; }
    }
}
