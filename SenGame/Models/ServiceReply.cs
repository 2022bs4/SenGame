using System;
using System.Collections.Generic;

#nullable disable

namespace SenGame.Models
{
    public partial class ServiceReply
    {
        public int ServiceId { get; set; }
        public string ReplyContent { get; set; }

        public virtual CustomerService Service { get; set; }
    }
}
