using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class Invite
    {
        public int InviteId { get; set; }
        public int UserId { get; set; }
        public int SenderId { get; set; }
        public string Message { get; set; }

        public virtual User Sender { get; set; }
        public virtual User User { get; set; }
    }
}
