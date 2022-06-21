using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class Blockade
    {
        public int? UserId { get; set; }
        public string BlockadeUserId { get; set; }
        public int BlockadeId { get; set; }

        public virtual User User { get; set; }
    }
}
